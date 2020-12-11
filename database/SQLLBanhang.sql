--create database ShopQuanAo
--go
create table admin
(
	Taikhoan nvarchar(100) primary key,
	Password varchar(10) not null default '123'
)
create table NhanVien
(
	MaNV varchar(10) primary key,
	TenNV nvarchar(100) not null,
	GioiTinh nvarchar(3) not null,
	NgaySinh date not null default getdate(),
	SDT varchar(10) not null,
	Luong varchar(10),
	DiaChi nvarchar(100) not null,
	Chucvu nvarchar(100) default N'Nhân viên'
	

)
create table DanhMuc
(
	
	MaDM varchar(10) primary key,
	TenDM nvarchar(100) not null
)
create table SanPham
(
	MaSP varchar(10) primary key,
	TenSP nvarchar(100) not null,
	MaDM varchar(10) not null,
	NhanHieu nvarchar(100) not null ,
	NgayCapNhat date not null default getdate(),
	Mota nvarchar(1000),
	GiaNhap int not null,
	Loinhuan float ,
	Gia int ,
	Hinh image,
	Nhap int,
	Ban int,
	Ton int
	foreign key (MaDM) references DanhMuc(MaDM)
)
create table KhachHang
(
	MaKH varchar(10) primary key,
	TenKH nvarchar(100),
	SDT varchar(10) 
	
)
create table HoaDon
(
	MaHD varchar(10) primary key,
	MaNV varchar(10) not null,
	MaKH varchar(10) not null,
	NgayTao date not null default getdate(),
	TongGia int,
	KhuyenMai int default 0,
	foreign key (MaNV) references NhanVien(MaNV),
	foreign key (MaKH) references KhachHang(MaKH)
)
create table ChiTiet
(
	MaCT int primary key    identity(1,1),
	MaHD varchar(10) not null,
	MaSP varchar(10) not null,
	SLBan int
	foreign key(MaHD) references HoaDon(MaHD)
)
----------DANH MỤC------------
insert into DanhMuc values ('DMALL', N'TẤT CẢ')
insert into DanhMuc values ('DMAT', N'ÁO THUN')
insert into DanhMuc values ('DMSM', N'ÁO SƠ MI')
insert into DanhMuc values ('DMQS', N'QUẦN SHORT')
insert into DanhMuc values ('DMQD', N'QUẦN DÀI')
insert into DanhMuc values ('DMCV', N'CHÂN VÁY')
insert into DanhMuc values ('DMVL', N'VÁY LIỀN')
insert into DanhMuc values ('DMYV', N'YẾM VÁY')
insert into DanhMuc values ('DMYQ', N'YẾM QUẦN')


---------SẢN PHẨM--------------
insert into SanPham values ('AT01',N'Áo thun axe','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT02',N'Áo thun cool','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT03',N'Áo thun drink soft','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT04',N'Áo thu giraffe','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT05',N'Áo thun oh hi girl','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT06',N'Áo thun snoopy','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT07',N'Áo thun tin tin','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('AT08',N'Áo thun value','DMAT',N'MÉO','2019/2/5',N'Chất liệu: Cotton',300000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('SM09',N'Áo sơ mi joni','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM10',N'Áo sơ mi ony','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM11',N'Áo sơ mi kola','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM12',N'Áo sơ mi ryo','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM13',N'Áo sơ mi surin','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM14',N'Áo sơ mi teky','DMSM',N'MÉO','2019/7/5',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('QS15',N'Quần short anzu','DMQS',N'MÉO','2019/11/5',N'Chất liệu: Cotton',250000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('QS16',N'Quần short arta','DMQS',N'MÉO','2019/11/5',N'Chất liệu: Cotton',250000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('QS17',N'Quần short mila','DMQS',N'MÉO','2019/11/5',N'Chất liệu: Cotton',250000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('QD18',N'Quần dài culotte ','DMQD',N'MÉO','2019/12/5',N'Chất liệu: Cotton',400000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('QD19',N'Quần dài iris','DMQD',N'MÉO','2019/1/5',N'Chất liệu: Cotton',400000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('QD20',N'Quần dài juli','DMQD',N'MÉO','2019/1/5',N'Chất liệu: Cotton',400000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('QD21',N'Quần dài lasri','DMQD',N'MÉO','2019/1/5',N'Chất liệu: Cotton',400000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('CV22',N'Chân váy colin','DMCV',N'MÉO','2019/6/5',N'Chất liệu: Cotton',370000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('CV23',N'Chân váy kate','DMCV',N'MÉO','2019/6/5',N'Chất liệu: Cotton',370000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('CV24',N'Chân váy loli','DMCV',N'MÉO','2019/6/5',N'Chất liệu: Cotton',370000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('CV25',N'Chân váy pana','DMCV',N'MÉO','2019/6/5',N'Chất liệu: Cotton',370000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('CV26',N'Chân váy suri','DMCV',N'MÉO','2019/6/5',N'Chất liệu: Cotton',370000,0.2,NULL,NULL,100,45,55)
insert into SanPham values ('VL27',N'Váy liền ali','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',550000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL28',N'Váy liền anne','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',600000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL29',N'Váy liền dolly','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',520000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL30',N'Váy liền julia','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',500000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL31',N'Váy liền jun','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',570000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL32',N'Váy liền oriole','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',580000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('VL33',N'Váy liền saling','DMVL',N'MÉO','2019/10/5',N'Chất liệu: Cotton',590000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('YV34',N'Yếm váy bera','DMYV',N'MÉO','2019/1/10',N'Chất liệu: Cotton',470000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('YV35',N'Yếm váy lora','DMYV',N'MÉO','2019/1/10',N'Chất liệu: Cotton',500000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('YV36',N'Yếm váy eulalia','DMYV',N'MÉO','2019/1/10',N'Chất liệu: Cotton',550000,0.15,NULL,NULL,100,45,55)
insert into SanPham values ('YQ37',N'Yếm quần elora','DMYQ',N'MÉO','2019/1/10',N'Chất liệu: Cotton',480000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('YQ38',N'Yếm quần freya','DMYQ',N'MÉO','2019/1/10',N'Chất liệu: Cotton',470000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM39',N'Áo sơ mi muriel','DMSM',N'MÉO','2019/1/10',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM40',N'Áo sơ mi sally','DMSM',N'MÉO','2019/1/10',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
insert into SanPham values ('SM41',N'Áo sơ mi sei','DMSM',N'MÉO','2019/1/10',N'Chất liệu: Cotton',450000,0.17,NULL,NULL,100,45,55)
----------NHÂN VIÊN-------------------------
insert into NhanVien values ('NV01',N'Trần Thị Vân Anh', N'Nữ','1999/2/13','0169785421',N'Bắc Từ Liêm, Hà Nội',5000000, N'Nhân viên')
insert into NhanVien values ('NV02',N'Nguyễn Ngọc Anh', N'Nữ','1999/5/16','0154236478',N'Cầu Giấy, Hà Nội',5000000,N'Nhân viên')
insert into NhanVien values ('NV03',N'Triệu Ninh Ngân', N'Nữ','1999/4/21','0178451245',N'Thanh Xuân, Hà Nội',5000000,N'Nhân viên')
insert into NhanVien values ('NV04',N'Nguyễn Thị Mơ', N'Nữ','1999/6/13','0987451245',N'Ba Đình, Hà Nội',5000000,N'Nhân viên')
insert into NhanVien values ('NV05',N'Phan Thị Mỹ Duyên', N'Nữ','1999/7/4','0147582124',N'Nam Từ Liêm, Hà Nội',5000000,N'Nhân viên')
insert into NhanVien values ('NV06',N'Đậu Thị Liên', N'Nữ','1999/9/19','0198745145',N'Cầu Giấy, Hà Nội',5000000,N'Nhân viên')
insert into NhanVien values ('NV07',N'Phạm Trọng Linh', N'Nam','1999/9/20','0985012473',N'Cầu Giấy, Hà Nội',8000000,N'Admin')
-----------------------------LOGIN---------------
insert into admin values(N'Admin','123')
insert into admin values(N'Nhân viên','111')


insert into KhachHang values('KH01',N'Nguyễn Trường An','0124578965')
insert into KhachHang values('KH02',N'Dương Đức Anh','0147895623')
insert into KhachHang values('KH03',N'Nguyễn Anh Dũng','0987451236')
insert into KhachHang values('KH04',N'Bùi Văn Dương','0978457861')
insert into KhachHang values('KH05',N'Nguyễn Đình Đại','0124587987')
insert into KhachHang values('KH06',N'Nguyễn Ngọc Hưng','0987457126')
insert into KhachHang values('KH07',N'Nguyễn Quốc Khánh','0963254178')
insert into KhachHang values('KH08',N'Nguyễn Văn Kiên','0987474512')
insert into KhachHang values('KH09',N'Nguyễn Thị Kim Khánh','0974581245')
insert into KhachHang values('KH10',N'Lê Thị Linh','0987451245')
insert into KhachHang values('KH11',N'Trần Thị Quỳnh Nga','0956124784')
insert into KhachHang values('KH12',N'Nguyễn Thị Thanh Thuỳ','0148751236')
insert into KhachHang values('KH13',N'Nguyễn Thị Lan','0165241783')
insert into KhachHang values('KH14',N'Nguyễn Thị Linh','0165241784')
insert into KhachHang values('KH15',N'Nguyễn Thị Ly','0165241785')
insert into KhachHang values('KH16',N'Nguyễn Thị Hoa','0165241786')
insert into KhachHang values('KH17',N'Nguyễn Thị Huyền','0165241787')
insert into KhachHang values('KH18',N'Nguyễn Thị Kim','0165241788')
insert into KhachHang values('KH19',N'Hồ Thị Kha','0165241789')
insert into KhachHang values('KH20',N'Hồ Thị Thu','0165241773')
insert into KhachHang values('KH21',N'Hồ Thị Thoa','0165241774')
insert into KhachHang values('KH22',N'Trần Thị Ngân','0165241775')
insert into KhachHang values('KH23',N'Trần Thị Nguyên','0165241776')
insert into KhachHang values('KH24',N'Phạm Thị Hương','0165241777')
insert into KhachHang values('KH25',N'Phạm Thị Trang','0165241778')
insert into KhachHang values('KH26',N'Phạm Thị Huệ','0165241779')
insert into KhachHang values('KH27',N'Đinh Thị Thảo','0165241760')
insert into KhachHang values('KH28',N'Đinh Thị Nhung','0165241761')--
insert into KhachHang values('KH29',N'Nguyễn Thị Thảo','0165241762')
insert into KhachHang values('KH30',N'Trần Thị Phương','0165241763')
insert into KhachHang values('KH31',N'Trần Thị Hà','0165241764')
insert into KhachHang values('KH32',N'Trần Thị Diễm','0165241765')
insert into KhachHang values('KH33',N'Lê Thị Hà','0165241766')
insert into KhachHang values('KH34',N'Lê Thị Như','0165241767')
insert into KhachHang values('KH35',N'Lê Thị Vân','0165241768')
insert into KhachHang values('KH36',N'Huỳnh Thị Thảo','0165241769')
insert into KhachHang values('KH37',N'Huỳnh Thị Ngọc','0165241750')
insert into KhachHang values('KH38',N'Trần Thị An','0165241751')
insert into KhachHang values('KH39',N'Trần Thị Anh','0165241752')
insert into KhachHang values('KH40',N'Hồ Thị Hoài','0165241753')
insert into KhachHang values('KH41',N'Hồ Thị Hiệp','0165241754')
insert into KhachHang values('KH42',N'Trần Thị Ly','0165241755')
insert into KhachHang values('KH43',N'Nguyễn Thị Lan','0165241756')
insert into KhachHang values('KH44',N'Nguyễn Thị Nhi','0165241757')
insert into KhachHang values('KH45',N'Phạm Thị Hằng','0165241758')
insert into KhachHang values('KH46',N'Phạm Thị Phượng','0165241759')
insert into KhachHang values('KH47',N'Trần Thị Cúc','0165241740')
insert into KhachHang values('KH48',N'Nguyễn Thị Thuỷ','0165241741')
insert into KhachHang values('KH49',N'Nguyễn Thị Loan','0165241742')
insert into KhachHang values('KH50',N'Phạm Thị Đào','0165241743')
insert into KhachHang values('KH51',N'Phạm Thị Hồng','0165241744')
insert into KhachHang values('KH52',N'Nguyễn Thị Giang','0165241745')
insert into KhachHang values('KH53',N'Hồ Thị Giang','0165241746')
insert into KhachHang values('KH54',N'Trần Thị Nga','0165241747')
insert into KhachHang values('KH55',N'Hồ Thị Nga','0165241748')
insert into KhachHang values('KH56',N'Hồ Thị Mai','0165241749')
insert into KhachHang values('KH57',N'Hồ Thị Minh','0165241730')
insert into KhachHang values('KH58',N'Nguyễn Thị Minh','0165241731')
insert into KhachHang values('KH59',N'Nguyễn Thị Ngân','0165241732')
insert into KhachHang values('KH60',N'Phạm Thị Ngân','0165241733')
insert into KhachHang values('KH61',N'Nguyễn Thị Trúc','0165241734')
insert into KhachHang values('KH62',N'Trần Thị Trúc','0165241735')
insert into KhachHang values('KH63',N'Nguyễn Thị Thuỳ','0165241736')
insert into KhachHang values('KH64',N'Phạm Thị Hương','0165241737')
insert into KhachHang values('KH65',N'Phạm Thị Thuỳ','0165241738')

insert into HoaDon values ('HD01','NV01','KH01','2019/10/17',NULL,0)
insert into HoaDon values ('HD02','NV01','KH02','2020/2/13',NULL,0)
insert into HoaDon values ('HD03','NV02','KH03','2019/3/14',NULL,0)
insert into HoaDon values ('HD04','NV02','KH04','2019/4/15',NULL,0)
insert into HoaDon values ('HD05','NV02','KH05','2019/3/2',NULL,0)
insert into HoaDon values ('HD06','NV03','KH06','2019/4/3',NULL,0)
insert into HoaDon values ('HD07','NV03','KH07','2019/7/14',NULL,0)
insert into HoaDon values ('HD08','NV04','KH08','2019/5/16',NULL,0)
insert into HoaDon values ('HD09','NV04','KH09','2019/8/7',NULL,0)
insert into HoaDon values ('HD10','NV04','KH10','2019/5/1',NULL,0)
insert into HoaDon values ('HD11','NV05','KH11','2019/6/3',NULL,0)
insert into HoaDon values ('HD12','NV05','KH12','2019/9/12',NULL,0)
insert into HoaDon values ('HD13','NV05','KH13','2019/6/13',NULL,0)
insert into HoaDon values ('HD14','NV05','KH14','2019/3/17',NULL,0)
insert into HoaDon values ('HD15','NV05','KH15','2019/2/2',NULL,0)
insert into HoaDon values ('HD16','NV05','KH16','2019/3/3',NULL,0)
insert into HoaDon values ('HD17','NV06','KH17','2019/5/14',NULL,0)
insert into HoaDon values ('HD18','NV06','KH18','2019/7/17',NULL,0)
insert into HoaDon values ('HD19','NV06','KH19','2019/6/22',NULL,0)
insert into HoaDon values ('HD20','NV06','KH20','2019/9/20',NULL,0)
insert into HoaDon values ('HD21','NV06','KH21','2019/3/21',NULL,0)
insert into HoaDon values ('HD22','NV01','KH22','2020/3/19',NULL,0)
insert into HoaDon values ('HD23','NV02','KH23','2019/9/17',NULL,0)
insert into HoaDon values ('HD24','NV03','KH24','2019/11/11',NULL,0)
insert into HoaDon values ('HD25','NV04','KH25','2019/10/11',NULL,0)
insert into HoaDon values ('HD26','NV05','KH26','2019/9/11',NULL,0)
insert into HoaDon values ('HD27','NV06','KH27','2019/8/11',NULL,0)
insert into HoaDon values ('HD28','NV01','KH28','2019/7/11',NULL,0)
insert into HoaDon values ('HD29','NV02','KH29','2019/6/11',NULL,0)
insert into HoaDon values ('HD30','NV03','KH30','2019/5/11',NULL,0)
insert into HoaDon values ('HD31','NV04','KH31','2019/4/11',NULL,0)
insert into HoaDon values ('HD32','NV05','KH32','2019/3/11',NULL,0)
insert into HoaDon values ('HD33','NV06','KH33','2020/2/11',NULL,0)
insert into HoaDon values ('HD34','NV01','KH34','2019/1/11',NULL,0)
insert into HoaDon values ('HD35','NV02','KH35','2019/12/15',NULL,0)
insert into HoaDon values ('HD36','NV03','KH36','2019/11/16',NULL,0)
insert into HoaDon values ('HD37','NV04','KH37','2019/10/17',NULL,0)
insert into HoaDon values ('HD38','NV05','KH38','2019/9/18',NULL,0)
insert into HoaDon values ('HD39','NV06','KH39','2019/8/19',NULL,0)
insert into HoaDon values ('HD40','NV01','KH40','2019/7/20',NULL,0)
insert into HoaDon values ('HD41','NV02','KH41','2019/6/21',NULL,0)
insert into HoaDon values ('HD42','NV03','KH42','2019/5/22',NULL,0)
insert into HoaDon values ('HD43','NV04','KH43','2019/4/23',NULL,0)
insert into HoaDon values ('HD44','NV05','KH44','2019/3/24',NULL,0)
insert into HoaDon values ('HD45','NV06','KH45','2019/2/25',NULL,0)
insert into HoaDon values ('HD46','NV01','KH46','2020/1/26',NULL,0)
insert into HoaDon values ('HD47','NV02','KH47','2019/12/27',NULL,0)
insert into HoaDon values ('HD48','NV03','KH48','2019/11/28',NULL,0)
insert into HoaDon values ('HD49','NV04','KH49','2019/10/29',NULL,0)
insert into HoaDon values ('HD50','NV05','KH50','2019/9/30',NULL,0)
insert into HoaDon values ('HD51','NV06','KH51','2019/8/1',NULL,0)
insert into HoaDon values ('HD52','NV01','KH52','2019/7/2',NULL,0)
insert into HoaDon values ('HD53','NV02','KH53','2019/6/3',NULL,0)
insert into HoaDon values ('HD54','NV03','KH54','2019/5/4',NULL,0)
insert into HoaDon values ('HD55','NV04','KH55','2019/4/5',NULL,0)
insert into HoaDon values ('HD56','NV05','KH56','2020/3/6',NULL,0)
insert into HoaDon values ('HD57','NV06','KH57','2019/2/7',NULL,0)
insert into HoaDon values ('HD58','NV01','KH58','2019/1/8',NULL,0)
insert into HoaDon values ('HD59','NV02','KH59','2019/12/9',NULL,0)
insert into HoaDon values ('HD60','NV03','KH60','2019/11/10',NULL,0)
insert into HoaDon values ('HD61','NV04','KH61','2019/10/11',NULL,0)
insert into HoaDon values ('HD62','NV05','KH62','2019/9/12',NULL,0)
insert into HoaDon values ('HD63','NV06','KH63','2019/8/13',NULL,0)
insert into HoaDon values ('HD64','NV01','KH64','2019/7/14',NULL,0)
insert into HoaDon values ('HD65','NV02','KH65','2019/6/15',NULL,0)
insert into HoaDon values ('HD66','NV03','KH01','2019/11/16',NULL,0)
insert into HoaDon values ('HD67','NV04','KH20','2019/5/17',NULL,0)
insert into HoaDon values ('HD68','NV05','KH02','2019/4/18',NULL,0)
insert into HoaDon values ('HD69','NV06','KH03','2020/3/19',NULL,0)
insert into HoaDon values ('HD70','NV01','KH04','2020/2/20',NULL,0)
insert into HoaDon values ('HD71','NV02','KH05','2020/1/21',NULL,0)
insert into HoaDon values ('HD72','NV03','KH06','2019/12/22',NULL,0)
insert into HoaDon values ('HD73','NV04','KH07','2019/11/23',NULL,0)
insert into HoaDon values ('HD74','NV05','KH08','2019/10/24',NULL,0)
insert into HoaDon values ('HD75','NV06','KH09','2019/9/25',NULL,0)
insert into HoaDon values ('HD76','NV01','KH10','2019/8/26',NULL,0)
insert into HoaDon values ('HD77','NV02','KH11','2019/7/27',NULL,0)
insert into HoaDon values ('HD78','NV03','KH12','2019/6/28',NULL,0)
insert into HoaDon values ('HD79','NV04','KH13','2019/5/29',NULL,0)
insert into HoaDon values ('HD80','NV05','KH14','2019/4/30',NULL,0)

insert into ChiTiet values ('HD01','AT01',1)
insert into ChiTiet values ('HD69','AT02',2)
insert into ChiTiet values ('HD01','AT03',2)
insert into ChiTiet values ('HD02','AT04',3)
insert into ChiTiet values ('HD70','AT03',1)
insert into ChiTiet values ('HD02','AT05',2)
insert into ChiTiet values ('HD03','AT01',2)
insert into ChiTiet values ('HD71','AT02',3)
insert into ChiTiet values ('HD04','AT06',1)
insert into ChiTiet values ('HD05','AT06',1)
insert into ChiTiet values ('HD72','AT04',2)
insert into ChiTiet values ('HD05','AT03',1)
insert into ChiTiet values ('HD06','AT01',1)
insert into ChiTiet values ('HD06','AT02',3)
insert into ChiTiet values ('HD07','AT06',2)
insert into ChiTiet values ('HD07','SM10',1)
insert into ChiTiet values ('HD24','SM11',1)
insert into ChiTiet values ('HD08','QS16',2)
insert into ChiTiet values ('HD73','QD20',2)
insert into ChiTiet values ('HD08','CV23',1)
insert into ChiTiet values ('HD09','QD21',3)
insert into ChiTiet values ('HD09','AT01',1)
insert into ChiTiet values ('HD23','QD20',1)
insert into ChiTiet values ('HD10','QS16',2)
insert into ChiTiet values ('HD10','QS17',1)
insert into ChiTiet values ('HD22','QD18',1)
insert into ChiTiet values ('HD11','SM13',2)
insert into ChiTiet values ('HD74','QS15',2)
insert into ChiTiet values ('HD21','AT02',3)
insert into ChiTiet values ('HD12','QS15',1)
insert into ChiTiet values ('HD75','AT08',1)
insert into ChiTiet values ('HD13','SM09',1)
insert into ChiTiet values ('HD13','SM11',2)
insert into ChiTiet values ('HD14','SM13',2)
insert into ChiTiet values ('HD14','SM14',1)
insert into ChiTiet values ('HD15','QS17',3)
insert into ChiTiet values ('HD16','QD19',3)
insert into ChiTiet values ('HD16','QD21',1)
insert into ChiTiet values ('HD17','SM11',1)
insert into ChiTiet values ('HD17','QD18',2)
insert into ChiTiet values ('HD20','QD19',1)
insert into ChiTiet values ('HD18','AT08',1)
insert into ChiTiet values ('HD18','AT05',1)
insert into ChiTiet values ('HD19','AT06',2)
insert into ChiTiet values ('HD01','AT01',1)
insert into ChiTiet values ('HD02','AT02',1)
insert into ChiTiet values ('HD03','AT03',1)
insert into ChiTiet values ('HD04','AT04',1)
insert into ChiTiet values ('HD05','AT05',1)
insert into ChiTiet values ('HD06','AT06',1)
insert into ChiTiet values ('HD07','AT07',1)
insert into ChiTiet values ('HD08','AT08',1)
insert into ChiTiet values ('HD09','SM09',1)
insert into ChiTiet values ('HD10','SM10',1)
insert into ChiTiet values ('HD11','SM11',1)
insert into ChiTiet values ('HD12','SM12',1)
insert into ChiTiet values ('HD13','SM13',1)
insert into ChiTiet values ('HD14','SM14',1)
insert into ChiTiet values ('HD15','QS15',1)
insert into ChiTiet values ('HD16','QS16',1)
insert into ChiTiet values ('HD17','QS17',1)
insert into ChiTiet values ('HD18','QD18',1)
insert into ChiTiet values ('HD19','QD19',1)
insert into ChiTiet values ('HD20','QD20',1)
insert into ChiTiet values ('HD21','QD21',1)
insert into ChiTiet values ('HD22','CV22',1)
insert into ChiTiet values ('HD23','CV23',1)
insert into ChiTiet values ('HD24','CV24',1)
insert into ChiTiet values ('HD25','CV25',1)
insert into ChiTiet values ('HD26','CV26',1)
insert into ChiTiet values ('HD27','VL27',1)
insert into ChiTiet values ('HD28','VL28',1)
insert into ChiTiet values ('HD29','VL29',1)
insert into ChiTiet values ('HD30','VL30',1)
insert into ChiTiet values ('HD31','VL31',1)
insert into ChiTiet values ('HD32','VL32',1)
insert into ChiTiet values ('HD33','VL33',1)
insert into ChiTiet values ('HD34','YV34',1)
insert into ChiTiet values ('HD35','YV35',1)
insert into ChiTiet values ('HD36','YV36',1)
insert into ChiTiet values ('HD37','YQ37',1)
insert into ChiTiet values ('HD38','YQ38',1)
insert into ChiTiet values ('HD39','SM39',1)
insert into ChiTiet values ('HD40','SM40',1)
insert into ChiTiet values ('HD41','SM41',1)
insert into ChiTiet values ('HD42','AT01',1)
insert into ChiTiet values ('HD43','AT02',1)
insert into ChiTiet values ('HD44','AT03',1)
insert into ChiTiet values ('HD45','AT04',1)
insert into ChiTiet values ('HD46','AT05',1)
insert into ChiTiet values ('HD47','AT06',1)
insert into ChiTiet values ('HD48','AT07',1)
insert into ChiTiet values ('HD49','AT08',1)
insert into ChiTiet values ('HD50','SM09',1)
insert into ChiTiet values ('HD21','SM10',1)
insert into ChiTiet values ('HD51','SM11',1)
insert into ChiTiet values ('HD52','SM12',1)
insert into ChiTiet values ('HD53','SM13',1)
insert into ChiTiet values ('HD54','SM14',1)
insert into ChiTiet values ('HD55','QS15',1)
insert into ChiTiet values ('HD56','QS16',1)
insert into ChiTiet values ('HD57','QS17',1)
insert into ChiTiet values ('HD58','QD18',1)
insert into ChiTiet values ('HD59','QD19',1)
insert into ChiTiet values ('HD60','QD20',1)
insert into ChiTiet values ('HD61','QD21',1)
insert into ChiTiet values ('HD62','CV22',1)
insert into ChiTiet values ('HD63','CV23',1)
insert into ChiTiet values ('HD64','CV24',1)
insert into ChiTiet values ('HD65','CV25',1)
insert into ChiTiet values ('HD66','CV26',1)
insert into ChiTiet values ('HD67','VL27',1)
insert into ChiTiet values ('HD68','VL28',1)
insert into ChiTiet values ('HD76','VL29',1)
insert into ChiTiet values ('HD77','VL30',1)
insert into ChiTiet values ('HD78','VL31',1)
insert into ChiTiet values ('HD79','VL32',1)
insert into ChiTiet values ('HD80','VL33',1)

update SanPham
set Gia  = GiaNhap*(1+Loinhuan)
update HoaDon
set TongGia = GiaBan.TGia
from (select MaHD, sum(SP.Gia * CT.SLBan) as TGia
       from SanPham SP, ChiTiet CT
	   where SP.MaSP = CT.MaSP
	   group by CT.MaHD
	  ) as GiaBan,
	   HoaDon HD
where GiaBan.MaHD = HD.MaHD

----------------------

 

--select HD.MaHD,CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia ,SP.Loinhuan, (SP.Gia*SP.Loinhuan) as Thuve
--from HoaDon HD, ChiTiet CT, SanPham SP
--where HD.MaHD = CT.MaHD
--and CT.MaSP = SP.MaSP
--and YEAR( HD.NgayTao) = ''
insert KhachHang values ('NV00',N'Nhân Viên',8888888888)

