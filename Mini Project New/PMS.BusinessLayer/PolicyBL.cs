using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DataAccessLayer;

namespace PMS.BusinessLayer
{
    public class PolicyBL
    {
        public static List<Policy> GetAllPolicyBL()
        {
            List<Policy> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.GetAllPolicyDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public static List<Customer> GetAllCustomerBL()
        {
            List<Customer> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.GetAllCustomerDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;

        }
        public static List<InsuranceProduct> GetAllProductsBL()
        {
            List<InsuranceProduct> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.GetAllProductsDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public static List<Endorsement> GetAllEndorsementBL()
        {
            List<Endorsement> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.GetAllEndorsementDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        //customer access grid
        public static List<Policy> GetPolicyCustomerAccessBL(string id)
        {
            List<Policy> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.GetPolicyCustomerAccessDAL(id);
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        //Name
        public static string GetNameCustomerBL(string id)
        {
            string name = string.Empty;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                name = obj.GetNameCustomerDAL(id);
            }
            catch (Exception)
            {

                throw;
            }
            return name;
        }
        //Customer on Policy Num
        public static Customer GetCustomerOnPolicyNumberBL(int custid)
        {
            Customer cus = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                cus = obj.GetCustomerOnPolicyNumberDAL(custid);
 
            }
            catch (Exception)
            {

                throw;
            }
            return cus;
        }
        public static InsuranceProduct GetInsuranceproductOnProductIdBL(int proid)
        {
            InsuranceProduct product = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                product = obj.GetInsuranceproductOnProductIdDAL(proid);
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }
        public static List<Policy> SearchByUsingDobAndNameBL(string id, DateTime dt, string nam)
        {
            List<Policy> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.SearchByUsingDobAndNameDAL(id, dt, nam);
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public static List<Policy> SearchByUsingCustomerNoBL(int num, string id)
        {
            List<Policy> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.SearchByUsingCustomerNoDAL(num, id);
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public static List<Policy> SearchByUsingPolicyNoBL(string policyNum, string id)
        {
            List<Policy> lst = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                lst = obj.SearchByUsingPolicyNoDAL(policyNum, id);
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public static bool CustomerLoginBL(string user, string pass)
        {
            bool valid = false;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                valid = obj.CustomerLoginDAL(user, pass);
            }
            catch (Exception)
            {

                throw;
            }
            return valid;
        }
        //View Policy
        public static Customer GetCustomerOnDobBL(DateTime dt)
        {
            Customer cus = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                cus = obj.GetCustomerOnDobDAL(dt);
            }
            catch (Exception)
            {

                throw;
            }
            return cus;
        }
        public static InsuranceProduct GetProductOnProductNameBL(string name)
        {
            InsuranceProduct prod = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                prod = obj.GetProductOnProductNameDAL(name);
            }
            catch (Exception)
            {

                throw;
            }
            return prod;
        }
        public static bool AddEndorsementBL(Endorsement end)
        {
            bool valid = false;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                valid = obj.AddEndorsementDAL(end);
            }
            catch (Exception)
            {

                throw;
            }
            return valid;
        }
        //View Endorsement Changes
        public static Policy GetPolicyonPolicyNoBL(string policynum)
        {
            Policy policy = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                policy = obj.GetPolicyonPolicyNoDAL(policynum);
            }
            catch (Exception)
            {

                throw;
            }
            return policy;
        }
        public static Customer GetCustomerOnPolicyNoBL(Policy p1)
        {
            Customer cus = null;
            try
            {
                PolicyDAL obj = new PolicyDAL();
                cus = obj.GetCustomerOnPolicyNoDAL(p1);
            }
            catch (Exception)
            {

                throw;
            }
            return cus;
        }
        public static void SaveChangesBL()
        {
            try
            {
                PolicyDAL obj = new PolicyDAL();
                obj.SaveChangesDAL();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddEndorsementStatusDAL(string policynum)
        {
            try
            {
                PolicyDAL obj = new PolicyDAL();
                obj.AddEndorsementStatusDAL(policynum);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AddEndorsementStatusRejDAL(string policynum)
        {
            try
            {
                PolicyDAL obj = new PolicyDAL();
                obj.AddEndorsementStatusRejDAL(policynum);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
