using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DataAccessLayer
{
    public class PolicyDAL
    {
        sqlpracticeEntities1 sq = new sqlpracticeEntities1();
        public List<Policy> GetAllPolicyDAL()
        {
            List<Policy> lst = null;
            try
            {
                lst = sq.Policys.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public List<Customer> GetAllCustomerDAL()
        {
            List<Customer> lst = null;
            try
            {
                lst = sq.Customers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public List<InsuranceProduct> GetAllProductsDAL()
        {
            List<InsuranceProduct> lst = null;
            try
            {
                lst = sq.InsuranceProducts.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public List<Endorsement> GetAllEndorsementDAL()
        {
            List<Endorsement> lst = null;
            try
            {
                lst = sq.Endorsements.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public List<Policy> GetPolicyCustomerAccessDAL(string id)
        {
            List<Policy> lst = null;

            try
            {
                var v2 = from e1 in sq.Logins where e1.LoginId == id select e1;
                foreach (var v in v2)
                {

                    lst = sq.Policys.Where(x => x.Customerno == v.CustomerId).Select(x => x).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public string GetNameCustomerDAL(string id)
        {
            string name = string.Empty;
            try
            {
                var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;
                foreach (var p in v1)
                {
                    Customer cus = sq.Customers.Single(x => x.CustId == p.CustomerId);
                    name = cus.Name;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return name;
        }
        public Customer GetCustomerOnPolicyNumberDAL(int custid)
        {
            Customer cus = null;
            try
            {
                cus = sq.Customers.Where(x => x.CustId == custid).Select(x => x).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return cus;
        }
        public InsuranceProduct GetInsuranceproductOnProductIdDAL(int proid)
        {
            InsuranceProduct product = null;
            try
            {
                product = sq.InsuranceProducts.Where(x => x.ProductId == proid).Select(x => x).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }
        public List<Policy> SearchByUsingDobAndNameDAL(string id, DateTime dt, string nam)
        {
            List<Policy> lst = null;
            try
            {
                var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;

                foreach (var v in v1)
                {

                    var v2 = from e2 in sq.Customers where e2.CustId == v.CustomerId select e2;

                    foreach (var v3 in v2)
                    {
                        lst = sq.Policys.Where(x => x.Customerno == v.CustomerId && v3.Name == nam && v3.Dob == dt).Select(x => x).ToList();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lst;

        }
        public List<Policy> SearchByUsingCustomerNoDAL(int num, string id)
        {
            List<Policy> lst = null;
            try
            {
                var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;
                foreach (var v in v1)
                {

                    lst = sq.Policys.Where(x => x.Customerno == v.CustomerId && x.Customerno == num).Select(x => x).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public List<Policy> SearchByUsingPolicyNoDAL(string policyNum, string id)
        {
            List<Policy> lst = null;
            try
            {
                var v1 = from e1 in sq.Logins where e1.LoginId == id select e1;
                foreach (var v in v1)
                {
                    lst = sq.Policys.Where(x => x.Customerno == v.CustomerId && x.PolicyNumber == policyNum).Select(x => x).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lst;
        }
        public bool CustomerLoginDAL(string user, string pass)
        {
            bool valid = false;
            try
            {
                var v1 = from e1 in sq.Logins where e1.LoginId == user select e1;
                if (v1 != null)
                {
                    foreach (var v in v1)
                    {
                        if (v.Password == pass)
                        {
                            valid = true;

                        }
                        else
                        {
                            valid = false;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return valid;
        }
        //ViewPolicy
        public Customer GetCustomerOnDobDAL(DateTime dt)
        {
            Customer customer = null;
            try
            {
                customer = sq.Customers.Where(x => x.Dob == dt).Select(x => x).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }
        public InsuranceProduct GetProductOnProductNameDAL(string name)
        {
            InsuranceProduct product=null;
            try
            {
                product = sq.InsuranceProducts.Where(x => x.Products == name).Select(x => x).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }
        public bool AddEndorsementDAL(Endorsement end)
        {
            bool add = false;
            try
            {
                sq.Endorsements.Add(end);
                sq.SaveChanges();
                add = true;
            }
            catch (Exception)
            {

                throw;
            }
            return add;
        }
        //View Endorsement Changes
        public Policy GetPolicyonPolicyNoDAL(string policynum)
        {
            Policy policy = null;
            try
            {
                policy = sq.Policys.Single(x => x.PolicyNumber == policynum);
            }
            catch (Exception)
            {

                throw;
            }
            return policy;
        }
        public Customer GetCustomerOnPolicyNoDAL(Policy p1)
        {
            Customer cus = null;
            try
            {
                cus = sq.Customers.Single(x => x.CustId == p1.Customerno);
            }
            catch (Exception)
            {

                throw;
            }
            return cus;
        }
        public void SaveChangesDAL()
        {
            sq.SaveChanges();
        }
        public void AddEndorsementStatusDAL(string policynum)
        {
            try
            {
                Endorsement end = sq.Endorsements.Where(x => x.Policynumber == policynum).OrderByDescending(x => x.TransactionId).First();
                end.EndorsementStatus = "Changes Accepted";
                sq.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddEndorsementStatusRejDAL(string policynum)
        {
            try
            {
                Endorsement end = sq.Endorsements.Where(x => x.Policynumber == policynum).OrderByDescending(x => x.TransactionId).First();
                end.EndorsementStatus = "Changes Rejected";
                sq.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public int AutoGenForCustomer()
        {
            int id = 0;
            try
            {
                id = sq.Customers.Max(x => x.CustId);
                id++;
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }


    }

} 
