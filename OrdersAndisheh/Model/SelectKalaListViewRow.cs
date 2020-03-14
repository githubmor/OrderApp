using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAndisheh.Model
{
    public class SelectKalaListViewRow
    {
        private KalaElectionDto dto;
        public SelectKalaListViewRow(KalaElectionDto _dto)
        {
            this.dto = _dto;
        }
        public string CodeKala
        {
            get { return dto.Code; }
        }
        public string KalaName
        {
            get { return dto.Name; }
        }

        
    }
}
