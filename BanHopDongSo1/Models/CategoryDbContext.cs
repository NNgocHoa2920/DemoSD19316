
using Microsoft.EntityFrameworkCore;

namespace BanHopDongSo1.Models
{
    //class này là class đại diện cho database của sql server 
    //khi các bạn muốn chạm đến csdl thì phải lôi cổ nó ra
    public class CategoryDbContext :DbContext
    {
        //cách 1: ném chuỗi kết nối ở dbcontext
        //Tạo contructor
        //không có tham số:ctor + tab/ nếu làm cách 2 thì k cần
        public CategoryDbContext()
        {
            
        }
        //có tham số: ctrl+. =. genverate contructor (options)
        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }

        //khởi tạo dbset
        //dbset đại diện cho 1 bảng ở trong db
        //khi chạm đến csdl thì phải gọi tới dbset
        public DbSet<Category> Categories { get; set; }

        //config chuỗi kết nối
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN; Database=SD19316_01;" +
        //        "Trusted_Connection= True;" +
        //            "TrustServerCertificate=True");
        //}

        //NẾU MUỐN ADD TRỰC TIẾP LUÔN DB THÌ LÀM K THÌ THÔI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Ma=1, Name="Khoai", Description="vàng"},
                    new Category { Ma=2, Name="Ngô", Description="vàng"},
                    new Category { Ma=3, Name="Sắn", Description="vàng"}
                );
        }

        //cách 2: config chuỗi kết nối ở trong appseting

        




    }
}
