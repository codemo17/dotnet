using System;
using System.Collections.Generic;
using ruslan.prototype.test.domain.models;
using ruslan.prototype.test.infrastructure.repositories;

namespace ruslan.prototype.test.services
{
    public class contactservice:icontactservice
    {
        public contactservice( icontactrepository repository)
        {
            _repository = repository;

        }
        
        #region icontacservices implemented
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<contact> getall()
        {
            return _repository.all();
        }
        /// <summary>
        /// 
        /// </summasiry>
        /// <param name="contact"></param>
        public void create(contact contact)
        {
            _repository.add(contact);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        public void save(domain.models.contact contact)
        {
            throw new NotImplementedException();
        }
        //
        public void remove(contact contact)
        {
            _repository.remove(contact);
        }

        
        #endregion

        #region fields

        private readonly icontactrepository _repository;

        #endregion


       
    }
}
