namespace SMSApi.Entity
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }     
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime AddmissionDate { get; set; }
        public int Fees { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return " Name" + this.Name + " , Email " + this.Email 
            + " , Addmission date " + this.AddmissionDate + "Status " + this.Status
            + " , Fees "+this.Fees + " , Phone "+this.Phone;
        }
    }
}
