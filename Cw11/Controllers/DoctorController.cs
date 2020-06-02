using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cw11.Models;
using Cw11.DTOs;

namespace Cw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalContext hospitalContext;

        public DoctorController(HospitalContext context)
        {
            this.hospitalContext = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            Doctor doctor = hospitalContext.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+id);
            }

            return Ok(doctor);
        }


        [HttpPost]
        public IActionResult AddDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor();

            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Email = doctorDTO.Email;

            hospitalContext.Doctors.Add(doctor);
            hospitalContext.SaveChanges();

            return Ok(doctor);
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorDTO doctorDTO)
        {

            Doctor doctor = hospitalContext.Doctors.Find(Int32.Parse(doctorDTO.IdDoctor));

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+doctorDTO.IdDoctor);
            }

            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Email = doctorDTO.Email;

            hospitalContext.Update(doctor);
            hospitalContext.SaveChanges();

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = hospitalContext.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+id);
            }

            hospitalContext.Doctors.Remove(doctor);
            hospitalContext.SaveChanges();
            

            return Ok();
        }
    }
}
