﻿using AnticevicApi.Model.Database.Main.Log;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnticevicApi.Model.Database.Main.Inv
{
    [Table(nameof(Device), Schema = "Inv")]
    public class Device : UserEntity, IHasValueId, IHasName
    {
        [Key]
        public int Id { get; set; }

        public string ValueId { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; }

        public ICollection<BrowserLog> BrowserLogs { get; set; }
    }
}
