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
    public class Position
    {
        #region Fields
        private int id;
        private string name;
        private string discription;
        private string duties;
        #endregion

        #region Properties
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "PositionName", DbType = "VARCHAR")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column(Name = "Discription", DbType = "VARCHAR")]
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        [Column(Name = "Duties", DbType = "VARCHAR")]
        public string Duties
        {
            get { return duties; }
            set { duties = value; }
        }
        #endregion

    }
}
