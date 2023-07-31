using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class NewFile
    {

    }

    public class MedicalHistory
    {
        public int MedicalHistoryId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<DiagnosticEvent> DiagnosticEvents { get; set; }
        public List<TreatmentEvent> TreatmentEvents { get; set; }
        public int InitialNurseId { get; set; }
        public Nurse InitialNurse { get; set; }
        public int CurrentNurseId { get; set; }
        public Nurse CurrentNurse { get; set; }
        public int InitialDoctorId { get; set; }
        public Doctor InitialDoctor { get; set; }
        public int CurrentDoctorId { get; set; }
        public Doctor CurrentDoctor { get; set; }
        public List<Department> Departments { get; set; }
        // Other relevant properties and methods
    }

    public class DiagnosticEvent
    {
        public int DiagnosticEventId { get; set; }
        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public string Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public List<PreDiagnosticEvent> PreDiagnosticEvents { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        // Other relevant properties and methods
    }

    public class PreDiagnosticEvent
    {
        public int PreDiagnosticEventId { get; set; }
        public int DiagnosticEventId { get; set; }
        public DiagnosticEvent DiagnosticEvent { get; set; }
        public string PreDiagnosis { get; set; }
        public DateTime Date { get; set; }
        // Other relevant properties and methods
    }

    public class TreatmentEvent
    {
        public int TreatmentEventId { get; set; }
        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public string Treatment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Medication> Medications { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        // Other relevant properties and methods
    }

    public class Medication
    {
        public int MedicationId { get; set; }
        public int TreatmentEventId { get; set; }
        public TreatmentEvent TreatmentEvent { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Route { get; set; }
        public string Frequency { get; set; }
        // Other relevant properties and methods
    }

    public class DemographicInformation
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public string InsuranceInformation { get; set; }
        // Other relevant properties and methods
    }

    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Other relevant properties and methods
    }

    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        // Other relevant properties and methods
    }

    public class Nurse
    {
        public int NurseId { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        // Other relevant properties and methods
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Nurse> Nurses { get; set; }
        // Other relevant properties and methods
    }
}
