using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using zdk.Membership.Web.Models;
using System.Data;

namespace zdk.Membership.Web.DALs
{
    public class TaskModelDAL 
    {
        public TaskModelDAL()
        {

        }
        public TaskModel GetById(int id)
        {
            List<TaskModel> rc = null;
            TaskModel um = new TaskModel();

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<TaskModel>("TasksGetById",
                    new
                    {
                        TaskId = id
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc.FirstOrDefault();

        }


        public List<TaskModel> GetAll(bool ServerAdmin)
        {

            List<TaskModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<TaskModel>("GetTaskModelALL",
                    new
                    {
                        ServerAdmin = ServerAdmin
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<TaskModel> GetByRoleId(Guid id)
        {

            List<TaskModel> rc = null;

            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<TaskModel>("TasksGetByRoleID",
                    new
                    {
                        RoleID = id
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public List<TaskModel> GetByUserId(Guid id)
        {

            List<TaskModel> rc = new List<TaskModel>();
            TaskModel task = null;

            switch (id.ToString())
            {
                case "54a961ed-d534-43db-8015-0253d209f4b0":
                    break;
                
                case "8d56cfb0-fa3c-4ebb-9b0f-7eb82643b61c": //fred
                    task = new TaskModel();
                    task.Controller = "Lock";
                    task.Action = "LowSecurity";
                    rc.Add(task);
                    break;

                default:
                    task = new TaskModel();
                    task.Controller = "Lock";
                    task.Action = "LowSecurity";
                    rc.Add(task);

                    task = new TaskModel();
                    task.Controller = "Lock";
                    task.Action = "HighSecurity";
                    rc.Add(task);
                    break;
            }

            /*
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                rc = con.Query<TaskModel>("TasksGetByUserID",
                    new
                    {
                        UserID = id
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }
            */
            return rc;

        }


        public void Insert(TaskModel model)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("TasksInsert",
                    new
                    {

                        Description = model.Description

                    },
                    null, null, CommandType.StoredProcedure);
            }
        }
        public void Save(TaskModel user)
        {
        }


        public bool Update(TaskModel model)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("TasksUpdateByID",
                    new
                    {
                        TaskID = model.TaskID,
                        Description = model.Description
                    },
                    null, null, CommandType.StoredProcedure);
            }

            return true;
        }
        public void Delete(Int32 taskID, Guid userID)
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                con.Open();
                con.Execute("TasksDelete",
                    new
                    {

                        TaskID = taskID
                        ,
                        UserId = userID
                    },
                    null, null, CommandType.StoredProcedure);
            }
        }

    }
}