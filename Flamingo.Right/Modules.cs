using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flamingo.Right
{
    public class Modules
    {
        //放映计划      
        public static Module Schedules
        {
            get
            {
                Module schedules = new Module();
                schedules.Id = ModuleIds.SchedulesId;
                schedules.Name = "放映计划";
                return schedules;
            }
        }

        //影院售票
        public static Module TicketSelling
        {
            get
            {
                Module ticketSelling = new Module();
                ticketSelling.Id = ModuleIds.TicketSellingId;
                ticketSelling.Name = "影院售票";
                return ticketSelling;
            }
        }

        //座位图
        public static Module SeatingChat
        {
            get
            {
                Module seatingChat = new Module();
                seatingChat.Id = ModuleIds.SeatingChatId;
                seatingChat.Name = "座位图工具";
                return seatingChat;
            }
        }

        //影院信息
        public static Module TheaterInformation
        {
            get
            {
                Module theaterInformation = new Module();
                theaterInformation.Id = ModuleIds.TheaterInformationId;
                theaterInformation.Name = "影院信息管理";
                return theaterInformation;
            }
        }

        //影片信息      
        public static Module FilmInformation
        {
            get
            {
                Module filmInformation = new Module();
                filmInformation.Id = ModuleIds.FilmInformationId;
                filmInformation.Name = "影片信息管理";
                return filmInformation;
            }
        }

        //员工管理
        public static Module EmployeeInformation
        {
            get
            {
                Module employeeInformation = new Module();
                employeeInformation.Id = ModuleIds.EmployeeInformationId;
                employeeInformation.Name = "用户管理";
                return employeeInformation;
            }
        }

        //票券管理       
        public static Module VoucherManager
        {
            get
            {
                Module voucherManager = new Module();
                voucherManager.Id = ModuleIds.VoucherManagerId;
                voucherManager.Name = "票券管理";
                return voucherManager;
            }
        }

        //票版管理
        public static Module TemplateManager
        {
            get
            {
                Module templateManager = new Module();
                templateManager.Id = ModuleIds.TemplateManagerId;
                templateManager.Name = "票版工具";
                return templateManager;
            }
        }

        //报表
        public static Module Report
        {
            get
            {
                Module report = new Module();
                report.Id = ModuleIds.ReportId;
                report.Name = "统计分析";
                return report;
            }
        }

        public static Module GetModuleById(int id)
        {
            if (id == 1)
            {
                return Schedules;
            }

            if (id == 2)
            {
                return TicketSelling;
            }

            if (id == 3)
            {
                return Report;
            }

            if (id == 4)
            {
                return TheaterInformation;
            }

            if (id == 5)
            {
                return FilmInformation;
            }

            if (id == 6)
            {
                return VoucherManager;
            }

            if (id == 7)
            {
                return SeatingChat;
            }

            if (id == 8)
            {
                return TemplateManager;
            }

            if (id == 9)
            {
                return EmployeeInformation;
            }

            Module module = new Module();
            module.Id = id;
            return module;
        }

        public static IList<Module> GetAllModules() 
        {
            IList<Module> modules = new List<Module>();
            modules.Add(Schedules);
            modules.Add(TicketSelling);
            modules.Add(Report);
            modules.Add(TheaterInformation);
            modules.Add(FilmInformation);
            modules.Add(VoucherManager);
            modules.Add(SeatingChat);
            modules.Add(TemplateManager);
            modules.Add(EmployeeInformation);
            return modules;
        }
    }
}
