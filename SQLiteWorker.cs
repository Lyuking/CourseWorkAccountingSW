using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_sw
{
    public class SQLiteWorker
    {
        public enum dataTables
        {
            employee_full,
            computer_full,
            computer_number,
            audience_full,
            licence_full,
            licence_details,
            licence_type,
            software,
            software_technical_details,
            software_name,
            subject_area
        }
        SQLiteConnection Connect;
        public SQLiteWorker(string path)
        {
            Connect = new SQLiteConnection(@"Data Source=" + path + ";datetimeformat=CurrentCulture;PRAGMA foreign_keys = 0;");
            Connect.Open();
        }
        public void ConnectionClose()
        {
            if(Connect.State == ConnectionState.Open)
                this.Connect.Close();
        }
        public DataTable SelectFromDB(dataTables table)
        {
            // строка запроса, который надо будет выполнить
            string commandText = "";
            switch (table)
            {
                case dataTables.audience_full:
                    commandText = "Select audience_number AS Номер from audience";
                    break;
                case dataTables.computer_full:
                    commandText = "Select audience_number as \"Номер аудитории\", computer_number as \"Номер компьютера\", computer_ip as \"IP-адрес\", computer_processor as Процессор, computer_videocard as Видеокарта," +
                    " computer_ram as RAM, computer_totalspace as \"Всего места\" from computer" +
                    " left join audience on audience.audience_id = computer.audience_id"; 
                    break;
                case dataTables.computer_number:
                   
                    break;
                case dataTables.software_name:
                    commandText = "Select software_name as \"Название П.О.\" from software_technical_details";
                    break;
                case dataTables.employee_full:
                    commandText = "Select employee_name as Имя, employee_surname as Фамилия, employee_patronymic as Отчество from employee as Отчество";
                    break;
                case dataTables.licence_full:
                    commandText = "Select software_name, licence_type_name, printf('%s %s %s', employee_name, employee_surname, employee_patronymic) " +
                        "from software_technical_details, licence_type, employee, software where (software.software_technical_details_id = software_technical_details.software_technical_details_id" +
                        " AND software.employee_id = employee.employee_id AND software.licence_id = licence_type.licence_type_id)";
                    break;
                case dataTables.licence_details:
                    commandText = "Select licence_key as Ключ, licence_date_start as \"Дата начала\", licence_date_end as \"Дата окончания\", licence_price as Цена from licence_details";
                    break;
                case dataTables.licence_type:
                    commandText = "Select licence_type_name as \"Тип лицензии\" from licence_type";
                    break;
                case dataTables.software:
                    commandText = "Select software_technical_details.software_name as Наименование, subject_area.subject_area_name as \"Предметная область\", " +
                        "software_technical_details.software_description as Описание, software_technical_details.software_required_space as \"Требуемое место\"," +
                        " software_technical_details.software_QR  from software_technical_details " +
                        "left join subject_area on subject_area.subject_area_id = software_technical_details.subject_area_id " +
                        "where subject_area.subject_area_id IN(Select software_technical_details.subject_area_id from software_technical_details)";
                    break;
                case dataTables.software_technical_details:
                    
                    break;
                case dataTables.subject_area:
                    commandText = "Select subject_area_name as \"Предметная область\" from subject_area";
                    break;
                default:
                    break;
            }
            DataTable dt = GetDataFromDB(commandText);
            return dt;
        }

        private DataTable GetDataFromDB(string commandText)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                SQLiteDataReader sqlReader = Command.ExecuteReader(); // выполнить запрос
            dt.Load(sqlReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectInstalledSoftwareOnPCFromDB(string pcnum)
        {
            return GetDataFromDB($"Select software_name from software_technical_details" +
                $" where software_technical_details.software_technical_details_id IN(Select software_technical_details_id from software " +
                $"where software.software_id IN(Select software_id from installed_software " +
                $"where installed_software.computer_id = (Select computer_id from installed_software " +
                $"where computer_id = (Select computer_id from computer where computer_number = {pcnum}))))");
        }
        public DataTable SelectLicencesFromSoftwareFromCurrentMachineFromDB(string softwareName, string pcnum)
        {
            return GetDataFromDB($"SELECT  licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\"," +
                $" licence_details.licence_date_start as \"Дата начала лицензии\", licence_details.licence_date_end as \"Дата окончания лицензии\"," +
                $" licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" FROM licence " +
                $"JOIN licence_type  ON licence_type.licence_type_id = licence.licence_type_id JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id " +
                $"LEFT JOIN employee on employee.employee_id = licence.employee_id " +
                $"where licence.licence_id in (Select licence_id from software " +
                $"where licence.licence_id in (Select software.licence_id from software " +
                $"where software.software_id IN(Select software.software_id from software " +
                $"where software.software_technical_details_id = (Select software_technical_details.software_technical_details_id from software_technical_details " +
                $"where software_technical_details.software_name = \"{softwareName}\")) " +
                $"AND software.software_id IN(Select installed_software.software_id from installed_software " +
                $"where installed_software.computer_id = (Select computer.computer_id from computer where computer.computer_number = \"{pcnum}\"))))");
        }
        public DataTable SelectComputerNumberFromDB(string audience)
        {
            return GetDataFromDB($"Select computer_number as \"Номер компьютера\" from computer " +
                $"where audience_id = (Select audience_id from audience where audience_number = \"{audience}\")");
        }
        public DataTable SelectLicenceFromSoftwareFromDB(string softwareName)
        {
            return GetDataFromDB($"SELECT  licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\", " +
                $"licence_details.licence_date_start as \"Дата начала лицензии\", licence_details.licence_date_end as \"Дата окончания лицензии\", " +
                $"licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" " +
                $"FROM licence JOIN licence_type  ON licence_type.licence_type_id = licence.licence_type_id " +
                $"JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id " +
                $"LEFT JOIN employee on employee.employee_id = licence.employee_id where licence.licence_id in (Select licence_id from software " +
                $"where licence.licence_id in (Select software.licence_id from software " +
                $"where software.software_id IN(Select software.software_id from software " +
                $"where software.software_technical_details_id = (Select software_technical_details.software_technical_details_id from software_technical_details " +
                $"where software_technical_details.software_name = \"{softwareName}\"))))");
        }
        public DataTable SelectSoftwareByAudFromDB(string audience)
        {
            return GetDataFromDB($"Select software_name as \"Название П.О.\" from software_technical_details " +
                $"where software_technical_details.software_technical_details_id IN(Select software_technical_details_id from software " +
                $"where software.software_id IN(Select software_id from installed_software where installed_software.computer_id IN(Select computer_id from installed_software " +
                $"where computer_id IN(Select computer_id from computer " +
                $"where audience_id = (Select audience_id from audience where audience_number = \"{audience}\")))))");
        }
        public DataTable SelectLicenceByAudAndSoftFromDB(string audience, string softwareName)
        {
            return GetDataFromDB($"SELECT  licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\"," +
                " licence_details.licence_date_start as \"Дата начала лицензии\", licence_details.licence_date_end as \"Дата окончания лицензии\"," +
                " licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" FROM licence " +
                "JOIN licence_type  ON licence_type.licence_type_id = licence.licence_type_id " +
                "JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id " +
                "left JOIN employee on employee.employee_id = licence.employee_id " +
                "where licence.licence_id in (Select licence_id from software " +
                "where software.software_id in (Select installed_software.software_id from installed_software " +
                "where installed_software.computer_id IN(Select computer.computer_id from computer " +
                $"where computer.audience_id = (Select audience.audience_id from audience where audience.audience_number = \"{audience}\"))) " +
                $"and software.software_technical_details_id = (Select software_technical_details_id from software_technical_details where software_name = \"{softwareName}\"))");
        }
        public DataTable SelectNotInstalledLicencesFromDB(string softwareName)
        {
            return GetDataFromDB($"SELECT  licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\", " +
                "licence_details.licence_date_start as \"Дата начала лицензии\", licence_details.licence_date_end as \"Дата окончания лицензии\", " +
                "licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" FROM licence " +
                "JOIN licence_type  ON licence_type.licence_type_id = licence.licence_type_id " +
                "JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id left " +
                "JOIN employee on employee.employee_id = licence.employee_id" +
                " where licence_id IN (Select licence_id from software" +
                " where software_id NOT IN (Select software_id from installed_software) " +
                $"and software_technical_details_id = (Select software_technical_details_id from software_technical_details where software_name = \"{softwareName}\"))");
        }
        bool ChangeDataIntoDB(params string[] commands)
        {
            using (var transaction = Connect.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        using (var sqliteCommand = new SQLiteCommand(command, Connect, transaction))
                        {
                            sqliteCommand.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public bool InsertNewSubjectArea(string subjectAreaName)
        {
            return ChangeDataIntoDB($"insert into subject_area (subject_area_name) values (\"{subjectAreaName}\")");
        }
        public bool InsertNewAudience(string audienceNumber)
        {
            return ChangeDataIntoDB($"insert into audience (audience_number) values (\"{audienceNumber}\")");
        }
        public bool InsertNewEmployee(string name, string surname, string patronymic)
        {
            return ChangeDataIntoDB($"insert into employee(employee_name, employee_surname, employee_patronymic) values(\"{name}\", \"{surname}\", \"{patronymic}\")");
        }
        public bool InsertNewSoftware(string subjectAreaName, string softwareName, string softwareDescription, string softwareReqSpace)
        {
            return ChangeDataIntoDB($"insert into software_technical_details (subject_area_id, software_name, software_description, software_required_space) " +
                $"values((Select subject_area_id from subject_area where subject_area_name = \"{subjectAreaName}\"), \"{softwareName}\", \"{softwareDescription}\", \"{softwareReqSpace}\")");
        }
        public bool InsertNewPC(string audienceNumber, string number, string ip, string processor, string videocard, string ram, string totalspace)
        {
            return ChangeDataIntoDB("INSERT into computer (audience_id, computer_number, computer_ip, computer_processor, computer_videocard, computer_ram, computer_totalspace) " +
                $"values((Select audience_id from audience where audience_number = \"{audienceNumber}\"), \"{number}\", \"{ip}\", \"{processor}\", \"{videocard}\", \"{ram}\", \"{totalspace}\")");           
        }
        public bool InsertNewLicence(string typeName, string employeeFullName, string softwareName, string key, DateTime datestart, DateTime dateEnd, string price)
        {
            return (ChangeDataIntoDB(InsertNewLicenceDetails(key, datestart, dateEnd, price), InsertNewLicence(typeName, key, employeeFullName), InsertNewLicenceToSoftware(softwareName, key)));               
        }
        private string InsertNewLicenceDetails(string key, DateTime datestart, DateTime dateEnd, string price)
        {
            return $"insert into licence_details (licence_key, licence_date_start, licence_date_end, licence_price) values (\"{key}\", \"{datestart}\", \"{dateEnd}\", \"{price}\")";
        }
        private string InsertNewLicence(string typeName, string key, string employeeFullName)
        {
            string[] employee = EmployeeSplit(employeeFullName);
            return $"insert into licence(licence_type_id, licence_details_id, employee_id)" +
                $" values((Select licence_type_id from licence_type where licence_type_name = \"{typeName}\")," +
                $" (Select licence_details_id from licence_details where licence_key = \"{key}\"), " +
                $"(Select employee_id from employee where employee_name = \"{employee[0]}\" AND employee_surname = \"{employee[1]}\" AND employee_patronymic = \"{employee[2]}\"))";
        }

        private static string[] EmployeeSplit(string employeeFullName)
        {
            string[] employee = { "", "", "" };
            string[] employeeSplit = employeeFullName.Split(' ');
            int i = 0;
            foreach (var item in employeeSplit)
            {
                employee[i] = item;
                i++;
            }

            return employee;
        }

        private string InsertNewLicenceToSoftware(string softwareName, string licenceKey)
        {
            return $"insert into software (software_technical_details_id , licence_id) " +
                $"values ((Select software_technical_details_id from software_technical_details where software_name = \"{softwareName}\")," +
                $" (Select licence_id from licence where licence_details_id = (Select licence_details_id from licence_details " +
                $"where licence_key = \"{licenceKey}\")))";
        }
        public bool InsertNewLicenceType(string licenceTypeName)
        {
            return ChangeDataIntoDB($"insert into licence_type (licence_type_name) values (\"{licenceTypeName}\")");
        }
        public bool InsertNewSoftwareToPC(string softwareName, string licenceKey, string computerNumber)
        {
            return ChangeDataIntoDB($"insert into installed_software (software_id, computer_id) " +
                $"values ((Select software_id from software " +
                $"where software_technical_details_id = (Select software_technical_details_id from software_technical_details " +
                $"where software_name = \"{softwareName}\") and licence_id = (Select licence_id from licence " +
                $"where licence_details_id = (Select licence_details_id from licence_details where licence_key= \"{licenceKey}\"))), " +
                $"(Select computer_id from computer where computer_number = \"{computerNumber}\"))");
        }
        byte[] LoadPhotoToArray(System.Drawing.Image image)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {
                //Здесь можно выбрать формат хранения
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
        public bool InsertNewSoftware(string subjectAreaName, string softwareName, string softwareDescription, string softwareReqSpace, System.Drawing.Image image)
        {
            return InsertORUpdateSoftwareWithQR($"insert into software_technical_details (subject_area_id, software_name, software_description, software_required_space, software_QR) " +
                $"values((Select subject_area_id from subject_area where subject_area_name = \"{subjectAreaName}\"), \"{softwareName}\", \"{softwareDescription}\", \"{softwareReqSpace}\", @photo)", image);
        }
        public bool UpdateSoftware(string oldSoftwareName, string subjectAreaName, string softwareName, string softwareDescription, string softwareReqSpace)
        {
            return ChangeDataIntoDB($"update software_technical_details set subject_area_id = (Select subject_area_id from subject_area where subject_area_name = \"{subjectAreaName}\")," +
                $" software_name = \"{softwareName}\", software_description = \"{softwareDescription}\", software_required_space = \"{softwareReqSpace}\"" +
                $" where software_name = \"{oldSoftwareName}\"");
        }
        public bool UpdateSoftware(string oldSoftwareName, string subjectAreaName, string softwareName, string softwareDescription, string softwareReqSpace, System.Drawing.Image image)
        {
            return InsertORUpdateSoftwareWithQR($"update software_technical_details set subject_area_id = (Select subject_area_id from subject_area where subject_area_name = \"{subjectAreaName}\")," +
                $" software_name = \"{softwareName}\", software_description = \"{softwareDescription}\", software_required_space = \"{softwareReqSpace}\", " +
                $"software_QR = @photo where software_name = \"{oldSoftwareName}\"", image);
        }
        private bool InsertORUpdateSoftwareWithQR(string commandText, System.Drawing.Image image)
        {
            byte[] imageArray = LoadPhotoToArray(image);
            try
            {

                SQLiteCommand command = new SQLiteCommand(commandText, Connect);
                command.CommandText = commandText;
                command.Parameters.Add("@photo", DbType.Binary).Value = imageArray;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePCInDB(string oldPCNum, string newPCNum, string pcIP, string pcProc, string pcVideocard, string pcRAM, string pcTotalSpace)
        {
            return ChangeDataIntoDB($"update computer set computer_number = \"{newPCNum}\", computer_ip = \"{pcIP}\", computer_processor = \"{pcProc}\", " +
                $"computer_videocard = \"{pcVideocard}\", computer_ram = \"{pcRAM}\", computer_totalspace = \"{pcTotalSpace}\" where computer_number = \"{oldPCNum}\";");
        }
        public bool UpdatePCInDB(string audienceNum, string oldPCNum, string newPCNum, string pcIP, string pcProc, string pcVideocard, string pcRAM, string pcTotalSpace)
        {
            return ChangeDataIntoDB($"update computer set audience_id = (Select audience_id from audience where audience_number = \"{audienceNum}\"), computer_number = \"{newPCNum}\", " +
                $"computer_ip = \"{pcIP}\", computer_processor = \"{pcProc}\", " +
                $"computer_videocard = \"{pcVideocard}\", computer_ram = \"{pcRAM}\", computer_totalspace = \"{pcTotalSpace}\" where computer_number = \"{oldPCNum}\";");
        }
        public bool UpdateAudience(string oldAudienceNum, string newAudienceNum)
        {
            return ChangeDataIntoDB($"update audience set audience_number = \"{newAudienceNum}\" where audience_number = \"{oldAudienceNum}\"");
        }
        public bool UpdateEmployee(string oldEmployeeName, string oldEmployeeSurname, string oldEmployeePatronymic, string newEmployeeName, string newEmployeeSurname, string newEmployeePatronymic)
        {
            return ChangeDataIntoDB($"update employee set employee_name = \"{newEmployeeName}\", employee_surname = \"{newEmployeeSurname}\", employee_patronymic = \"{newEmployeePatronymic}\" " +
                $"where employee_name = \"{oldEmployeeName}\" and employee_surname = \"{oldEmployeeSurname}\" and employee_patronymic = \"{oldEmployeePatronymic}\"");
        }
        public bool UpdateSubjectArea(string oldSubjectAreaName, string newSubjectAreaName)
        {
            return ChangeDataIntoDB($"update subject_area set subject_area_name = \"{newSubjectAreaName}\" where subject_area_name = \"{oldSubjectAreaName}\"");
        }
        public bool UpdateLicenceType(string oldLicenceTypeName, string newLicenceTypeName)
        {
            return ChangeDataIntoDB($"update licence_type set licence_type_name = \"{newLicenceTypeName}\" where licence_type_name = \"{oldLicenceTypeName}\"");
        }
        public bool UpdateIntalledSoftware(string newComputerNumber, string newSoftwareName, string newKey, string oldComputerNumber, string oldSoftwareName, string oldKey)
        {
            return ChangeDataIntoDB($"update installed_software set computer_id = (Select computer_id from computer where computer_number = \"{newComputerNumber}\")," +
                $" software_id = (Select software_id from software where software_technical_details_id = (Select software_technical_details_id from software_technical_details" +
                $" where software_name = \"{newSoftwareName}\") and licence_id = (select licence_id from licence where licence_details_id = (Select licence_details_id from licence_details" +
                $" where licence_key = \"{newKey}\"))) where computer_id = (Select computer_id from computer where computer_number = \"{oldComputerNumber}\") and software_id = (Select software_id from software" +
                $" where software_technical_details_id = (Select software_technical_details_id from software_technical_details where software_name = \"{oldSoftwareName}\")" +
                $" and licence_id = (select licence_id from licence where licence_details_id = (Select licence_details_id from licence_details where licence_key = \"{oldKey}\")))");
        }
        
        public bool UpdateLicence( string licenceTypeName, string employeeFullName, string newLicenceKey, string dateStart, string dateEnd, string price, string oldKey)
        {
            return ChangeDataIntoDB(UpdateLicenceTypeInCurrentLicence(licenceTypeName, oldKey),
                UpdateEmployeeInCurrentLicence(employeeFullName, oldKey), UpdateLicenceDetailsInCurrentLicence(newLicenceKey, dateStart, dateEnd, price, oldKey));
        }
        private string UpdateLicenceTypeInCurrentLicence(string licenceTypeName, string oldLicenceKey)
        {
            return $"update licence set licence_type_id = (Select licence_type_id from licence_type where licence_type_name = \"{licenceTypeName}\") " +
                $"where licence_details_id = (Select licence_details_id from licence_details where licence_key = \"{oldLicenceKey}\");";
        }
        private string UpdateEmployeeInCurrentLicence(string employeeFullName, string oldLicenceKey)
        {
            string[] employee = EmployeeSplit(employeeFullName);
            return $"update licence set employee_id = (Select employee_id from employee " +
                $"where employee_name = \"{employee[0]}\" and employee_surname = \"{employee[1]}\" and employee_patronymic = \"{employee[2]}\") " +
                $"where licence_details_id = (Select licence_details_id from licence_details where licence_key = \"{oldLicenceKey}\");";
        }
        private string UpdateLicenceDetailsInCurrentLicence(string newLicenceKey, string dateStart, string dateEnd, string price, string oldKey)
        {
            return $"update licence_details set licence_key = \"{newLicenceKey}\", licence_date_start = \"{dateStart}\", licence_date_end = \"{dateEnd}\", licence_price = \"{price}\" where licence_key = \"{oldKey}\";";
        }
        public bool DeleteInstalledSoftware(string computerNumber, string key)
        {
            return ChangeDataIntoDB($"Delete from installed_software where computer_id = (Select computer_id from computer where computer_number = \"{computerNumber}\")" +
                $" and software_id = (Select software_id from software where licence_id = (Select licence_id from licence " +
                $"where licence_details_id = (Select licence_details_id from licence_details where licence_key = \"{key}\")))");
        }
        public bool DeleteEmployeeFromDB(string employeeFullName)
        {
            string[] employee = EmployeeSplit(employeeFullName);
            return ChangeDataIntoDB($"delete from employee where employee_name = \"{employee[0]}\" and employee_surname = \"{employee[1]}\" and employee_patronymic = \"{employee[2]}\"");
        }
        public bool DeleteAudienceFromDB(string audienceNum)
        {
            return ChangeDataIntoDB($"detele from audience where audience_number = \"{audienceNum}\"");
        }
        public bool DeleteComputerFromDB(string computerNum)
        {
            return ChangeDataIntoDB($"delete from computer where computer_number = \"{computerNum}\"");
        }
        public bool DeleteSubjectAreaFromDB(string subjectAreaName)
        {
            return ChangeDataIntoDB($"delete from subject_area where subject_area_name = \"{subjectAreaName}\"");
        }
        public bool DeleteLicenceTypeFromDB(string licenceTypeName)
        {
            return ChangeDataIntoDB($"delete from licence_type where licence_type_name = \"{licenceTypeName}\"");
        }
        public bool DeleteLicenceFromDB(string licenceKey)
        {
            return ChangeDataIntoDB($"delete from licence_details where licence_key = \"{licenceKey}\"");
        }
        public bool DeleteSoftwareFromDB(string softwareName)
        {
            return ChangeDataIntoDB($"delete from software_technical_details where software_nam = \"{softwareName}\"");
        }
        public DataTable SelectSoftwareBySubjectArea(string subjectArea)
        {
            return GetDataFromDB($"Select software_name from software_technical_details where subject_area_id IN (Select subject_area_id from subject_area where subject_area_name = \"{subjectArea}\")");
        }
        public DataTable SelectLicencesBySubjectAreaAndSoftware(string subjectAreaName, string softwareName)
        {
            return GetDataFromDB($"SELECT  licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\", licence_details.licence_date_start as \"Дата начала лицензии\"," +
                " licence_details.licence_date_end as \"Дата окончания лицензии\", licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" FROM licence " +
                "LEFT JOIN licence_type  ON licence_type.licence_type_id = licence.licence_type_id " +
                "JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id left " +
                "JOIN employee on employee.employee_id = licence.employee_id " +
                "where licence.licence_id in (Select licence_id from software where software.software_id IN(Select software.software_id from software " +
                "where software.software_technical_details_id = (Select software_technical_details.software_technical_details_id from software_technical_details " +
               $"where software_technical_details.software_name = \"{softwareName}\" and software_technical_details.subject_area_id = (Select subject_area_id from subject_area where subject_area_name = \"{subjectAreaName}\"))))");
        }
        public DataTable SelectSoftwareByLicenceType(string licenceTypeName)
        {
            return GetDataFromDB($"Select software_name from software_technical_details where software_technical_details_id in (Select software_technical_details_id from software " +
                $"where licence_id in (Select licence_id from licence where licence_type_id = (Select licence_type_id from licence_type where licence_type_name = \"{licenceTypeName}\")))");
        }
        public DataTable SelectLicencesByLicenceTypeAndSoftware(string licenceTypeName, string softwareName)
        {
            return GetDataFromDB("SELECT licence_type.licence_type_name as \"Тип лицензии\", licence_details.licence_key as \"Ключ\", licence_details.licence_date_start as \"Дата начала лицензии\", licence_details.licence_date_end as \"Дата окончания лицензии\"," +
                " licence_details.licence_price as \"Цена лицензии\", printf('%s %s %s', employee_name, employee_surname, employee_patronymic) as \"Ответственное лицо\" FROM licence left" +
                " JOIN licence_type ON licence_type.licence_type_id = licence.licence_type_id " +
                "JOIN licence_details on licence_details.licence_details_id = licence.licence_details_id left " +
                "JOIN employee on employee.employee_id = licence.employee_id where licence.licence_id in (Select licence_id from software " +
                "where software.software_id IN (Select software.software_id from software where software.software_technical_details_id = (Select software_technical_details.software_technical_details_id from software_technical_details " +
                $"where software_technical_details.software_name = \"{softwareName}\")) and licence.licence_type_id = (Select licence_type_id from licence_type where licence_type_name = \"{licenceTypeName}\"))");
        }
    }
}
