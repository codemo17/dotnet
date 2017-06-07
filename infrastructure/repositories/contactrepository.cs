using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ruslan.prototype.test.domain.models;

namespace ruslan.prototype.test.infrastructure.repositories
{
    public class contactrepository : icontactrepository
    {

        #region ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datafilepath"></param>
        public contactrepository(string datafilepath)
        {
            _contacts = loadxml(datafilepath);
        }

        #endregion

        #region irepository<contact> implemented

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        public void add(contact contact)
        {
            if (!_contacts.Contains(contact))
            {
                _contacts.Add(contact);
            }
            else
            {
                var existing = _contacts.Single(c => c.id.Equals(contact.id));

                if(existing!=null)
                {
                    existing.name = contact.name;
                    existing.lastname = contact.lastname;
                    existing.bio = contact.bio;
                    existing.dateofbirth = contact.dateofbirth;
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public contact single(string id)
        {

            return all().First(c => c.id == id);
         }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<contact> all()
        {
            return _contacts;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate"></param>
        public void remove(contact aggregate)
        {
            _contacts.Remove(aggregate);
        }
        

        #endregion

        #region helpers
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static List<contact> loadxml(string datafilepath)
        {
            try
            {
               var result = new List<contact>();
               using (var reader = new XmlTextReader(datafilepath))
                {
                   while (reader.Read())
                   {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "contact")
                            {
                              result.Add(
                                new contact(reader.GetAttribute("id") as string)
                                {
                                   name = reader.GetAttribute("name") as string,
                                   lastname = reader.GetAttribute("lastname") as string,
                                   dateofbirth = reader.GetAttribute("dateofbirth")
                                });
                            }
                        }
                    }

                }

                return result;
            }
            catch
            {
                return null;
            }
        }
    


    #endregion

        #region fields

        private readonly List<contact> _contacts;
     
        

        #endregion



       
    }
}
