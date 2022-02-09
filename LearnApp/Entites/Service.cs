//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LearnApp.Entites
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ClientService = new HashSet<ClientService>();
            this.ServicePhoto = new HashSet<ServicePhoto>();
        }

        public Service(int iD, string title, decimal cost, int durationInSeconds, decimal costWithDiscount, string description, double? discount, string mainImagePath, ICollection<ClientService> clientService, ICollection<ServicePhoto> servicePhoto)
        {
            ID = iD;
            Title = title;
            Cost = cost;
            DurationInSeconds = durationInSeconds;
            CostWithDiscount = costWithDiscount;
            Description = description;
            Discount = discount;
            MainImagePath = mainImagePath;
            ClientService = clientService;
            ServicePhoto = servicePhoto;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int DurationInSeconds { get; set; }
        public decimal CostWithDiscount { get; set; }
        public string Description { get; set; }
        public Nullable<double> Discount { get; set; }
        public string MainImagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePhoto> ServicePhoto { get; set; }

        public ServiceModel ToServiceModel(Boolean isAdmin)
        {
            ServiceModel model = new ServiceModel(ID, Title, Cost, DurationInSeconds, Description, Discount, MainImagePath, ClientService, ServicePhoto);
            if(model.Discount > 0)
            {
                model.isHighlited = true;
            }
            model.isAdmin = isAdmin;
            return model;
        }

        internal ServiceModel ToServiceModel(object isAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
