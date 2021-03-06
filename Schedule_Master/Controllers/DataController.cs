﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule_Master.Models;

namespace Schedule_Master.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        IDAO Singleton = IDAO.Singleton;

        [HttpGet("GetUsers")]
        public List<UserModel> GetUsers() { return Singleton.Users; }

        [HttpGet("GetSchedules")]
        public List<ScheduleModel> GetSchedules(int userid)
        {
            if (userid == 0)
            {
                return Singleton.Schedules;
            }
            else
            {
                return Singleton.Schedules.Where(s => s.User_ID == userid).ToList();
            }
        }

        [HttpGet("GetColumns")]
        public List<ColumnModel> GetColumns() { return Singleton.Columns; }

        [HttpGet("GetSlots")]
        public List<SlotModel> GetSlots() { return Singleton.Slots; }

        [HttpGet("GetTasks")]
        public List<TaskModel> GetTasks() { return Singleton.Tasks; }

        [HttpPost("Schedule")]
        public void Schedule(string[] table)
        {
            Singleton.CreateSchedule(table[0], int.Parse(table[1]));
        }

        [HttpPost("GetSlotOfSchedule/{id}")]
        public List<SlotModel> GetSlotOfSchedule(int id)
        {
            return Singleton.GetSlotsOfSchedule(id);
        }

        [HttpPost("GetColumnsOfSchedule/{id}")]
        public List<ColumnModel> GetColumnsOfSchedule(int id)
        {
            return Singleton.GetColumnsByScheduleID(id);
        }

        [HttpPost("GetUserSchedules/{id}")]
        public List<ScheduleModel> GetUserSchedule(int id)
        {
            return Singleton.GetUserSchedules(id);
        }

        [HttpPost("GetTasksOfSchedule/{id}")]
        public List<TaskModel> GetTasksOfSchedule(int id)
        {
            return Singleton.GetScheduleTasks(id);
        }

        /*
        [HttpPost("Column")]
        public void Column(string[] table)
        {
            //title, schedule_id
            Singleton.CreateColumn(table[0], int.Parse(table[1]));
        }

        [HttpPost("Slot")]
        public void Slot(string[] table)
        {
            //column_id, hour
            Singleton.CreateSlot(int.Parse(table[0]), int.Parse(table[1]));
        }
        */

        [HttpPost("DeleteTask")]
        public void DeleteTask(string[] data)
        {
            Singleton.DeleteTask(int.Parse(data[0]));
        }

        [HttpPost("UpdateTask")]
        public void UpdateTask(string[] data)
        {
            //title, slotid
            Singleton.EditTask(data[0], int.Parse(data[1]));
        }

        [HttpPost("Task")]
        public void Task(string[] table)
        {
            //title, slotid
            Singleton.CreateTask(table[0], int.Parse(table[1]));
        }

        [HttpGet("schedule/{id}")]
        public List<ScheduleModel> ValidSchedule(int id)
        {

            List<ScheduleModel> schedule = Singleton.GetSchedule(id);
            return schedule;
        }


        [HttpGet("log")]
        public List<LogModel> GetLogs()
        {
            return Singleton.ReadLog();
        }
    }
}
