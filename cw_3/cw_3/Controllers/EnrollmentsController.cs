﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using cw_3.Models;
using cw_3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw_3.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        public readonly string conString = "Data Source=db-mssql;Initial Catalog=s19270;Integrated Security=True";
        IStudentDbService service = new SqlServerDbService();
        
        [HttpPost]
        public IActionResult CreateStudent(NewStudent student)
        {
            return Ok(service.AddStudent(student));
        }

        [HttpPost("promotions")]
        public IActionResult Promote([FromBody]String studies, [FromBody]int semester)
        {
            return Ok(service.PromoteStudents(studies, semester));
        }
    }
}