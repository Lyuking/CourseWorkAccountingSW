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
        static int tmp = 0;
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
            subject_area
        }
        SQLiteConnection Connect;
        public SQLiteWorker(string path)
        {
            Connect = new SQLiteConnection(@"Data Source=" + path + ";datetimeformat=CurrentCulture");
            Connect.Open();
        }
        ~SQLiteWorker()
        {
            if(Connect != null)
            {
                Connect.Close();
            }
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
                    " computer_ram as RAM, computer_totalspace as \"Всего места\" from computer, audience where(audience.audience_id = computer.audience_id)";
                    break;
                case dataTables.computer_number:
                   
                    break;
                case dataTables.employee_full:
                    commandText = "Select employee_name as Имя, employee_surname as Фамилия, employee_patronymic as Отчество from employee as Отчество";
                    break;
                //case "installed_software":
                //    commandText = "Select computer_number, software_name from "
                //    break;
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
                        "join subject_area on subject_area.subject_area_id = software_technical_details.subject_area_id " +
                        "where subject_area.subject_area_id IN(Select software_technical_details.subject_area_id from software_technical_details)";
                    //commandText = "Select software_name, licence_type_name, employee_name, employee_surname, employee_patronymic from software_technical_details, licence_type, employee, software" +
                    //    " where (software.software_technical_details_id = software_technical_details.software_technical_details_id AND software.employee_id = employee.employee_id " +
                    //    "AND software.licence_id = licence.licence_id)";
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
                //if (tmp ==2)
                //{
                //    DateTime datetime = sqlReader.GetDateTime(3);
                //}
            dt.Load(sqlReader);
            }
            catch (Exception ex)
            {
                //exception
            }
            tmp++;
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
                $"where audience_id = (Select audience_id from audience where audience_number = \"404-5а\")))))");
        }
        public DataTable SelectLicenceByAudFromDB(string audience)
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
                "where computer.audience_id = (Select audience.audience_id from audience where audience.audience_number = \"404-1\"))))");
        }

    }
}
