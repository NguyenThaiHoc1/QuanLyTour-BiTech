using System;
using System.Data.Entity;
using MySql.Data.Entity;

using System.Collections.Generic;
using System.Linq;

using Core.Model;

namespace Data
{
    public class DBInitializer : CreateDatabaseIfNotExists<TourBitechContext>
    {
        protected override void Seed(TourBitechContext context)
        {
            using (var ctx = new TourBitechContext())
            {
                // Please see source code for implementation
            }
        }
    } 

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TourBitechContext : DbContext
    {
        public TourBitechContext() : base("myConnectString")
        {
            Database.SetInitializer<TourBitechContext>(new DBInitializer());
        }

        public DbSet<DanhGiaTour> DanhGiaTour { get; set; }
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<facethongke> facethongke { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HopDongDangKyTour> HopDongDangKyTour { get; set; }
        public DbSet<HoTroKhachHang> HoTroKhachHang { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<LoaiNhanVien> LoaiNhanVien { get; set; }
        public DbSet<LoaiTour> LoaiTour { get; set; }
        public DbSet<Ngay> Ngay { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhuongTien> PhuongTien { get; set; }
        public DbSet<TheThanhToan> TheThanhToan { get; set; }
        public DbSet<ThongBao> ThongBao { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<ChiTietKhachHangTour> ChiTietKhachHangTour { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // config many to many
            // 1. 

            modelBuilder.Entity<Tour>().HasMany<DichVu>(s => s.DichVuTours).WithMany(c => c.Tours).Map(cs =>
            {
                cs.MapLeftKey("TourRefId");
                cs.MapRightKey("DichVuRefId");
                cs.ToTable("ChiTietDichVu");
            });


            // 2
            modelBuilder.Entity<Tour>().HasMany<PhuongTien>(s => s.PhuongTiens).WithMany(c => c.Tours).Map(cs =>
            {
                cs.MapLeftKey("TourRefId");
                cs.MapRightKey("PhuongTienRefId");
                cs.ToTable("TourPhuongTien");
            });

            //modelBuilder.Entity<Tour>().HasMany<KhachHang>(s => s.KhachHangs).WithMany(c => c.Tours).Map(cs =>
            //{
            //    cs.MapLeftKey("TourRefId");
            //    cs.MapRightKey("KhachHangRefId");
            //    cs.ToTable("KhachHangChiTietTour");
            //});


            modelBuilder.Entity<ChiTietKhachHangTour>().HasKey(bc => new { bc.KhachHangID, bc.TourID });

            base.OnModelCreating(modelBuilder);

        }


    }
}
