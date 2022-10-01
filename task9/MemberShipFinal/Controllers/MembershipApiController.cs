using ClassLibrary5;
using MemberShipFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace MemberShipFinal.Controllers
{
    public class MembershipApiController : ApiController
    {
        MembershipEntities db=new MembershipEntities();
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetData()
        {
            Class1 obj = new Class1();
            obj.connection();
            DataSet l = obj.selectCondoctor();
            var list = l.Tables[0].AsEnumerable().Select(DataRow => new login
            {
                UserId = DataRow.Field<int>("UserId"),
                Name = DataRow.Field<string>("Name"),
                password = DataRow.Field<string>("password"),
                email = DataRow.Field<string>("email"),
                Mobile_No = DataRow.Field<string>("Mobile_No")
            });
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult insertData1(login l)
        {
            int id = l.UserId;
            string name=l.Name;
            string pass = l.password;
            string email = l.email;
            string mo = l.Mobile_No;
            Class1 obj = new Class1();
            obj.connection();
            obj.insertData(id, name, pass, email, mo);
            db.SaveChanges();
            MembershipUser newUser = Membership.CreateUser(l.Name, l.password);
            
            return Ok();
        }
    }
}
