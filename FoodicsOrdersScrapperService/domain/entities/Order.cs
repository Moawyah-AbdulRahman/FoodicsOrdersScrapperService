namespace FoodicsOrdersScrapperService.domain.entities;

public class Order
{
    public string id { get; set; }
    public string app_id { get; set; }
    public string? promotion_id { get; set; }
    public int? discount_type { get; set; }
    public string? reference_x { get; set; }
    public int? number { get; set; }
    public int type { get; set; }
    public int source { get; set; }
    public int status { get; set; }
    public int? delivery_status { get; set; }
    public int guests { get; set; }
    public string? kitchen_notes { get; set; }
    public string? customer_notes { get; set; }
    //public DateTime business_date { get; set; }
    public double subtotal_price { get; set; }
    public double discount_amount { get; set; }
    public double rounding_amount { get; set; }
    public double total_price { get; set; }
    public double tax_exclusive_discount_amount { get; set; }
    public int? delay_in_seconds { get; set; }
    //public Meta? meta { get; set; }
    
    // TODO : the meta needs more invistigation.
    // 1) documenttion missmatch!
    // 2) products_kitchen is a list of objects!
    //public class Meta
    //{
    //    public Foodics foodics { get; set; }

    //    public class Foodics
    //    {
    //        public string device_id { get; set; }

    //    }
    //}
    //public DateTime? opened_at { get; set; }
    //public DateTime? accepted_at { get; set; }
    //public DateTime? due_at { get; set; }
    //public DateTime? driver_assigned_at { get; set; }
    //public DateTime? dispatched_at { get; set; }
    //public DateTime? driver_collected_at {  get; set; }
    //public DateTime? delivered_at { get; set; }
    //public DateTime? closed_at { get; set; }
    //public DateTime? created_at { get; set; }

    // This field is used to fetch records of data
    // Documentation says this is unique identifier and nullable
    // but it in all orders it's not null
    // in the documentation it's used as an index to fetch all records through pagination
    public int reference { get; set; }
    public int check_number { get; set; }

}