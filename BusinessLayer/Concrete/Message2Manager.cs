﻿using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;
        

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddT(Message2 t)
        {
            throw new NotImplementedException();
        }


        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

    
        public List<Message2> GetList()
        {
            return _messageDal.GetListAll();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            return _messageDal.GetByID(id);

        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }
    }
}
