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
        SQLiteConnection Connect;
        public SQLiteWorker(string path)
        {
            Connect = new SQLiteConnection(@"Data Source=" + path);
            Connect.Open();
        }
        public DataTable SelectFromDB(string tableName)
        {
            // строка запроса, который надо будет выполнить
            string commandText = "";
            switch (tableName)
            {
                case "audience":
                    commandText = "Select audience_number from audience";
                    break;
                case "computer":
                    commandText = "Select audience_number, computer_number, computer_ip computer_processor, computer_videocard," +
                    " computer_ram computer_totalspace from computer, audience where(audience.audience_id = computer.audience_id)";
                    break;
                case "employee":
                    commandText = "Select employee_name, employee_surname, employee_patronymic from employee";
                    break;
                //case "installed_software":
                //    commandText = "Select computer_number, software_name from "
                //    break;
                case "licence":
                    commandText = "Select software_name, licence_type_name, printf('%s %s %s', employee_name, employee_surname, employee_patronymic) " +
                        "from software_technical_details, licence_type, employee, software where (software.software_technical_details_id = software_technical_details.software_technical_details_id" +
                        " AND software.employee_id = employee.employee_id AND software.licence_id = licence_type.licence_type_id)";
                    break;
                case "licence_details":
                    commandText = "Select licence_key, licence_date_start, licence_date_end, licence_price from licence_details";
                    break;
                case "licence_type":
                    commandText = "Select licence_type_name from licence_type";
                    break;
                case "software":
                    commandText = "Select software_name, licence_type_name, employee_name, employee_surname, employee_patronymic from software_technical_details, licence_type, employee, software" +
                        " where (software.software_technical_details_id = software_technical_details.software_technical_details_id AND software.employee_id = employee.employee_id " +
                        "AND software.licence_id = licence.licence_id)";
                    break;
                case "software_technical_details":
                    commandText = "Select subject_area_name, software_name, software_description, software_required_space, software_QR from subject_area, software_technical_details" +
                        " where (subject_area.subject_area_id = software_technical_details.subject_area_id)";
                    break;
                case "subject_area":
                    commandText = "Select subject_area_name from subject_area";
                    break;
                default:
                    break;
            }
            DataTable dt = new DataTable();
            try
            {
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                SQLiteDataReader sqlReader = Command.ExecuteReader(); // выполнить запрос
                dt.Load(sqlReader);
            }
            catch (Exception ex)
            {
                //exception
            }
            return dt;
        }
    }
}
