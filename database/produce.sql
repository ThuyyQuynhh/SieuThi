create proc Report1(@mahd as varchar(10))
as
begin 
	select  TenNV,HoaDon.MaKH, TenKH ,HoaDon.MaHD, NgayTao,ChiTiet.MaSP, TenSP,ThuongHieu,Donvi, Gia , SLBan, KhuyenMai, TongGia 
	from    ChiTiet, HoaDon, KhachHang,NhanVien,SanPham
	where   ChiTiet.MaHD = HoaDon.MaHD and HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaNV = NhanVien.MaNV and ChiTiet.MaSP = SanPham.MaSP and HoaDon.MaHD =@mahd
end
exec Report1 'HD01'
