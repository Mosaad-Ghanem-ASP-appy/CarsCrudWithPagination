using X.PagedList;

namespace CarsCrudWithPagination.Models
{
    public class CarDetailsViewModel
    {
        public Car Car { get; set; }
        public Paginition Paginition { get; set; }
    }
    public class CarsViewModel
    {
        public Car Car { get; set; }
        public IPagedList<Car> OnePageOfCars { get; set; }
    }

}
