using System;
using System.Collections.Generic;
using Core.Model;

namespace Core.Services
{
    public interface IFactThongKeService
    {

        IEnumerable<facethongke> NapDuLieuHoaDon(DateTime NgayBD, DateTime NgayKT);
        IEnumerable<facethongke> NapDuLieuHopDong(DateTime NgayBD, DateTime NgayKT);
        decimal TinhTongChiPhi(int num, string type);
        int TinhTongSoLuong(int num, string type);
        decimal TinhTongDatCoc(int num, string type);
        decimal TinhTongSoTienThanhToan(int num, string type);
        int TinhTongHoaDon(int num, string type);
        int TinhTongHopDong(int num, string type);
        List<facethongke> XuatExcel();
        //IEnumerable<FactThongKe> NapDuLieuHopDong(DateTime ngaybd, DateTime ngaykt);

        //IEnumerable<FactThongKe> NapDuLieuHoaDon(int ngaybd, int ngaykt, string loaithoigian);


    }
}
