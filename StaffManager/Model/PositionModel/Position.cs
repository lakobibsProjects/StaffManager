using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.PositionModel
{
    [AddINotifyPropertyChangedInterface]
    [Table(Name = "Positions")]
    public class Position : IEntity
    {
        #region Fields
        private int id;
        private string name;
        private string discription;
        private string duties;
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        public string Duties
        {
            get { return duties; }
            set { duties = value; }
        }
        #endregion

    }
}
