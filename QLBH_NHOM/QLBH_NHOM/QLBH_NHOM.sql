create database QLBH_NHOM
use QLBH_NHOM

CREATE TABLE KHACHHANG(
MAKH VARCHAR(20) PRIMARY KEY,
TENKH NVARCHAR(50),
GIOITINH BIT,
EMAIL_KH VARCHAR(100),
SDT VARCHAR(11),
DIACHI NVARCHAR(200),
TENDANGNHAP VARCHAR(50),
MATKHAU VARCHAR(50)
)

CREATE TABLE NHANVIEN(
MANV VARCHAR(20) PRIMARY KEY,
HOTENNV NVARCHAR(50),
GIOITINH BIT,
EMAIL_NV VARCHAR(100),
SDT VARCHAR(11),
QUYENNV INT, --1 LÀ ADMIN, 2 LÀ NV, 3 LÀ SHIPPER
TENDANGNHAP VARCHAR(50),
MATKHAU VARCHAR(50)
)

CREATE TABLE NHOMSANPHAM(
MANHOM VARCHAR(6) PRIMARY KEY,
TENNHOM NVARCHAR(100)
)

CREATE TABLE SANPHAM(
MASP VARCHAR(6) PRIMARY KEY,
MANHOM VARCHAR(6),
TENSP NVARCHAR(50),
DONGIA INT,
GIAGIAM  INT,
MOTA NVARCHAR(300),
TINHTRANG BIT, --1 LÀ CÒN HÀNG, 2 LÀ HẾT HÀNG
LINK_HINHANH VARCHAR(100),
SOLUONG INT
)


CREATE TABLE CHITIET_DONHANG(
MADON VARCHAR(6),
MASP VARCHAR(6),
DH_SOLUONG TINYINT,
DH_GIABAN INT,
PRIMARY KEY(MADON, MASP),

)

CREATE TABLE DONHANG(
MADON VARCHAR(6) PRIMARY KEY,
MAKH VARCHAR(20),
MANV_DUYET VARCHAR(20) NULL,
MANV_GIAO VARCHAR(20) NULL,
NGAYDAT DATE,
NGAYGIAO DATE,
DIACHIGIAO NVARCHAR(200),
TINHTRANG VARCHAR(2),
TIEN INT
)

CREATE TABLE GIAMGIA(
MAGIAMGIA VARCHAR(10) PRIMARY KEY,
MASP VARCHAR(6),
PHANTRAMGIAM TINYINT,
NGAYAPDUNG DATE,
)

CREATE TABLE TINHTRANGDON(
	TINHTRANG VARCHAR(2) PRIMARY KEY,
	MOTA NVARCHAR(100),
)

CREATE TABLE DANHGIA(
MADANHGIA VARCHAR(6) PRIMARY KEY,
MASP VARCHAR(6),
MAKH VARCHAR(20),
SOSAODANHGIA TINYINT,
NGAYDANHGIA DATE,
CHITIETDANHGIA NVARCHAR(200)
)


ALTER TABLE SANPHAM
ADD CONSTRAINT MANHOM_SP_FK FOREIGN KEY (MANHOM) REFERENCES NHOMSANPHAM(MANHOM)


ALTER TABLE GIAMGIA
ADD CONSTRAINT MASP_GG_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)


ALTER TABLE DANHGIA
ADD CONSTRAINT MASP_DG_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE DANHGIA
ADD CONSTRAINT MAKH_DG_FK FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)


ALTER TABLE DONHANG
ADD CONSTRAINT MAKH_DH_FK FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE DONHANG
ADD CONSTRAINT MANV_DH_NV FOREIGN KEY (MANV_DUYET) REFERENCES NHANVIEN(MANV)
ALTER TABLE DONHANG
ADD CONSTRAINT MANVGIAO_DH_NV FOREIGN KEY (MANV_GIAO) REFERENCES NHANVIEN(MANV)

ALTER TABLE DONHANG
ADD CONSTRAINT TINHTRANG_DH_TT FOREIGN KEY (TINHTRANG) REFERENCES TINHTRANGDON(TINHTRANG)


ALTER TABLE CHITIET_DONHANG
ADD CONSTRAINT MASP_CTDH_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
ALTER TABLE CHITIET_DONHANG
ADD CONSTRAINT MADON_CTDH_FK FOREIGN KEY (MADON) REFERENCES DONHANG(MADON)


insert into NHANVIEN
values 
('NV01', N'Nguyễn Đức Huy', 1,'huynd@gmail.com', '0984512362',1,'huyadmin', '202cb962ac59075b964b07152d234b70'),
('NV02', N'Chế Đức Tài', 1, 'taicd@gmail.com', '0923651269',1,'taiadmin', 'c8ffe9a587b126f152ed3d89a146b445'),
('NV03', N'Lê Nguyễn Việt Hoàng',1, 'hoanglnv@gmail.com', '0581236549',1,'hoangadmin', '3def184ad8f4755ff269862ea77393dd'),

('NV04', N'Nguyễn Phương Thanh',0,'thanhnp@gmail.com', '0586123652',2,'thanhddon', 'a123'),
('NV05', N'Nguyễn Trọng Nghĩa',1, 'nghiant@gmail.com', '0945128745',2,'nghiaddon', 'a123'),
('NV06', N'Nguyễn Trung Quân', 1,'quantn@gmail.com', '0771592348',2,'quanddon', 'a123'),
('NV07', N'Đỗ Minh Nhật',0, 'minhnd@gmail.com', '0432551269',2,'minhddon', 'a123'),
('NV08', N'Trần Nhật Vỹ',1, 'vytn@gmail.com', '0584575949',2,'vyddon', 'a123'),
('NV09', N'Hoàng Lệ Nam',0, 'namhl@gmail.com', '0903145236',2,'namddon', 'a123'),
('NV10', N'Trần Long', 1,'longt@gmail.com', '0922634985',2,'longddon', 'a123'),


('NV11', N'Hồ Hoài Anh', 1,'anhhh@gmail.com', '0581236549',3,'anhhoaishipper', '12345'),
('NV12', N'Nguyễn Trung Quân',1, 'quantn@gmail.com', '0984512362',3,'quanshipper', '12345'),
('NV13', N'Trần Nhật Thanh', 1,'thanhtn@gmail.com', '0581236549',3,'thanhshipper', '12345'),
('NV14', N'Lê Quốc Thành', 1,'thanhlq@gmail.com', '0581236549',3,'thanhshipper', '12345'),
('NV15', N'Nguyễn Thành Nghĩa',1, 'nghiant@gmail.com', '0984512362',3,'nghiashipper', '12345'),
('NV16', N'Phạm Văn Quân', 1,'quanpv@gmail.com', '0581236549',3,'quanpvshipper', '12345'),
('NV17', N'Lê Trọng Kha', 1,'khalt@gmail.com', '0581236549',3,'khashipper', '12345'),
('NV18', N'Hồ Thị Kim Thoa', 0,'thoahtk@gmail.com', '0984512362',3,'thoashipper', '12345'),
('NV19', N'Trương Thị Thùy Trang',0, 'trangttt@gmail.com', '0581236549',3,'trangshipper', '12345'),
('NV20', N'Đặng Ngọc Luyến',1, 'luyendn@gmail.com', '0581236549',3,'luyenshipper', '12345'),
('NV21', N'Nguyễn Trần Quân',1, 'quannt2@gmail.com', '0984512362',3,'quanntshipper', '12345'),
('NV22', N'Nguyễn Thành Danh',1, 'danhnt@gmail.com', '0581236549',3,'danhshipper', '12345'),
('NV23', N'Phạm Tấn Thành', 1,'thanhtp@gmail.com', '0581236549',3,'thanhptshipper', '12345'),
('NV24', N'Lê Huy Phú', 1,'phulh@gmail.com', '0581236549',3,'huyphushipper', '12345'),
('NV25', N'Hoàng Trung',1, 'trungh@gmail.com', '0984512362',3,'htrungshipper', '12345'),
('NV26', N'Phan Thanh Hòa', 1,'hoapt@gmail.com', '0581236549',3,'hoaptshipper', '12345'),
('NV27', N'Nguyễn Tiến Tài',1, 'taitien@gmail.com', '0581236549',3,'taitienshipper', '12345'),
('NV28', N'Phùng Văn Trường',1, 'truongpv@gmail.com', '0984512362',3,'vtruongshipper', '12345'),
('NV29', N'Võ Dương Thái Vinh', 1,'vinhvdt@gmail.com', '0581236549',3,'tvinhshipper', '12345'),
('NV30', N'Nguyễn Ngọc Huy', 1,'huynn@gmail.com', '0581236549',3,'nhuyshipper', '12345')


insert into KHACHHANG
values
('KH01', N'Nguyễn Phước Thái', 1,'thaitp@gmail.com', '0378549632', N'20 Tôn Thất Tùng, Nha Trang','thaiphuoc', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH02', N'Nguyễn Quang', 1,'quangnguyen@gmail.com', '0623591452', N'80 Đoàn Trần Nghiệp, Nha Trang','quangnguyen', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH03', N'Trần Xuân Phước', 1,'phuocxuan@gmail.com', '0124785632', N'660 Chợ Đầm, Nha Trang','xuanphuoc', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH04', N'Lê Long Thành',1, 'thanhll@gmail.com', '0192489632', N'18 Hoàng Diệu, Nha Trang','thanhlelong', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH05', N'Đào Long Thiên', 1,'longthien@gmail.com', '0321499632', N'77 Hòn Chồng, Nha Trang','longthien123', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH06', N'Đỗ Xuân Hơn', 1,'honxuan@gmail.com', '0951798565', N'66 Hải Đức, Nha Trang','xuanhon123', '6789'),
('KH07', N'Võ Thanh Minh',1, 'minhvothanh@gmail.com', '0225597845', N'12, Đoàn Trần Nghiệp, Nha Trang','minhvothanh', '46d045ff5190f6ea93739da6c0aa19bc'),
('KH08', N'Hoàng Thế Hiển', 1,'hienthe@gmail.com', '0187951482', N'15 Nguyễn Đình Chiểu, Nha Trang','hoanghien', '6789'),
('KH09', N'Nguyễn Phước Tiến',1, 'tienphuoc@@gmail.com', '0951623478', N'188 Yersin, Nha Trang','tiennguyenphuoc', '6789'),
('KH10', N'Nguyễn Hải', 1,'hainguyen@gmail.com', '0336259874', N'77A Pasteur, Nha Trang','hainguyen147', '6789'),

('KH11', N'Trần Nguyễn Hãn',1, 'hannguyen@gmail.com', '0378549632', N'34 Phước Đồng, Nha Trang','hannguyen2206', '6789'),
('KH12', N'Lê Thanh Mai',0, 'mailt@gmail.com', '0623591452', N'14 Trần Hưng Đạo, Nha Trang','mai147', '6789'),
('KH13', N'Trần Như Quỳnh', 0,'quynhnhu@gmail.com', '0124785632', N'66 Nguyễn Xiển, Nha Trang','quynhnhu12', '6789'),
('KH14', N'Đỗ Thanh Ngân', 0,'ngandt@gmail.com', '0192489632', N'10 Nguyễn Thiện Thuật, Nha Trang','dongan98', '6789'),
('KH15', N'Lê Trường Lâm', 1,'truongll@gmail.com', '0321499632', N'89, Trần Phú, Nha Trang','truonglamle771', '6789'),
('KH16', N'Châu Thái Sơn', 1,'sonthai@gmail.com', '0951798565', N'66B khu 3, Lê Lợi, Nha Trang','thaisonpica', '6789'),
('KH17', N'Nguyễn Văn Nhã',1, 'nhanv@gmail.com', '0225597845', N'134 Nguyễn Trung Trực, Nha Trang','nhatdt', '6789'),
('KH18', N'Nguyễn Hữu Thanh', 1,'thanhnh@gmail.com', '0187951482', N'15 Nguyễn Thị Định, Nha Trang','thanhhuun', '6789'),
('KH19', N'Trần Thủy Tiên', 0,'tienttc@@gmail.com', '0951623478', N'77A Vĩnh Hải','tien6150', '6789'),
('KH20', N'Nguyễn Công Vinh',1, 'vinhnc@gmail.com', '0336259874', N'88 Vĩnh Nguyên, Nha Trang','vinhcongtsn', '6789'),

('KH21', N'Huỳnh Thanh Nhật', 0,'nhatthanhp@gmail.com', '0378549632', N'92 Tôn Thất Thuyết, Nha Trang','nhatthanhp', '6789'),
('KH22', N'Nguyễn Quỳnh Trang',0, 'quynhtrang@gmail.com', '0623591452', N'80 Đoàn Trần Nghiệp, Nha Trang','quynhtrang', '6789'),
('KH23', N'Nguyễn Minh Thư', 0,'thuminh@gmail.com', '0124785632', N'660 Chợ Đầm, Nha Trang','thuminh', '6789'),
('KH24', N'Nguyễn Thị Ngọc Trinh', 0,'trinhngoc@gmail.com', '0192489632', N'18 Hoàng Diệu, Nha Trang','trinhngocs2', '6789'),
('KH25', N'Diệp Thanh Ân',1, 'diepan@gmail.com', '0321499632', N'77 Hòn Chồng, Nha Trang','diepanhoang', '6789'),
('KH26', N'Mai Tài Phến', 1,'phenmaitai@gmail.com', '0951798565', N'66 Hải Đức, Nha Trang','maitaiphen', '6789'),
('KH27', N'Nguyễn Tâm Như', 0,'tamnhung@gmail.com', '0225597845', N'12, Đoàn Trần Nghiệp, Nha Trang','nhutam66', '6789'),
('KH28', N'Hoàng Thế Mỹ', 0,'myhoang@gmail.com', '0187951482', N'15 Nguyễn Đình Chiểu, Nha Trang','myhoang', '6789'),
('KH29', N'Hồ Quốc Trung', 1,'hotrung@@gmail.com', '0951623478', N'188 Yersin, Nha Trang','hotrung', '6789'),
('KH30', N'Nguyễn Phú Nghĩa', 1,'nghianguyenn@gmail.com', '0336259874', N'77A Pasteur, Nha Trang','phungia7749', '6789')

insert into TINHTRANGDON
VALUES
('1', N'Chờ xác nhận'),
('2', N'Đã xác nhận'),
('3', N'Đang vận chuyển'),
('4', N'Đã giao'),
('5', N'Đã hủy đơn')

insert into DONHANG
VALUES
('HD001', 'KH01', 'NV04', 'NV11', '2021-04-12', '2021-04-12', N'20 Tôn Thất Tùng, Nha Trang','4', 50000),
('HD002', 'KH02', 'NV10', 'NV15', '2021-05-01', '2021-05-01',  N'80 Đoàn Trần Nghiệp, Nha Trang','4', 50000),
('HD003', 'KH03', 'NV05', 'NV25', '2021-03-08', '2021-03-08',N'660 Chợ Đầm, Nha Trang','4', 50000),

('HD004', 'KH04', 'NV05', 'NV16', '2021-02-06', '2021-02-06', N'18 Hoàng Diệu, Nha Trang','4', 50000),
('HD005', 'KH05', 'NV09', 'NV20', '2021-05-05', '2021-05-05',  N'77 Hòn Chồng, Nha Trang','4', 50000),
('HD006', 'KH06', 'NV08', 'NV19', '2021-04-06', '2021-04-06', N'66 Hải Đức, Nha Trang','4', 50000),

('HD007', 'KH02', 'NV07', 'NV16', '2021-02-06', '2021-02-06',N'80 Đoàn Trần Nghiệp, Nha Trang','4', 50000),
('HD008', 'KH07', 'NV07', 'NV20', '2021-05-05', '2021-05-05',   N'12, Đoàn Trần Nghiệp, Nha Trang','4', 50000),
('HD009', 'KH05', 'NV10', 'NV19', '2021-04-06', '2021-04-06', N'15 Nguyễn Đình Chiểu, Nha Trang','4', 50000),

('HD010', 'KH08', 'NV04', 'NV22', '2021-04-05', '2021-04-05',  N'15 Nguyễn Đình Chiểu, Nha Trang','4', 50000),
('HD011', 'KH09', 'NV05', 'NV23', '2021-04-05', '2021-04-05',N'188 Yersin, Nha Trang','4', 50000),
('HD012', 'KH04', 'NV08', 'NV21', '2021-02-06', '2021-02-06', N'18 Hoàng Diệu, Nha Trang','4', 50000),

('HD013', 'KH10', null, null, '2021-03-03', '2021-03-03',  N'77A Pasteur, Nha Trang','1', 50000),
('HD014', 'KH11', null, null, '2021-04-05', '2021-04-05', N'34 Phước Đồng, Nha Trang','1', 50000),
('HD015', 'KH12', null, null, '2021-04-06', '2021-04-06', N'14 Trần Hưng Đạo, Nha Trang','1', 50000)

INSERT INTO NHOMSANPHAM
VALUES
	('NSP01',N'Gà'),
	('NSP02',N'Hamburger'),
	('NSP03',N'Bánh mì'),
	('NSP04',N'Pizza'),
	('NSP05',N'Sandwich'),
	('NSP06',N'Spaghetti'),
	('NSP07',N'Xúc xích'),
	('NSP08',N'Đồ uống'),
	('NSP09',N'Khoai tây'),
	('NSP10',N'Hành tây')

INSERT INTO SANPHAM
VALUES
	('SP01', 'NSP01', N'Cánh gà nướng',30000, 20000,N'Cánh gà nướng cùng sốt mật ong thơm ngon, khẩu phần 2 người ăn',1,'canh_ga_nuong.jpg',1),
	('SP02', 'NSP01', N'Cánh gà rán',35000,30000,N'Cánh gà rán bột giòn ăn kèm với sốt chanh, khẩu phần 1 người ăn', 1, 'canh_ga_ran.jpg',1),
	('SP03', 'NSP01', N'Đùi gà nướng',55000,50000,N'Đùi gà nướng than hồng, khẩu phần 2 người ăn', 1,'dui_ga_nuong.jpg',1),
	('SP04', 'NSP01', N'Đùi gà rán',65000,50000,N'Đùi gà rán không dầu, khẩu phần 1 người ăn', 1,'dui_ga_ran.jpg',1),
	('SP05', 'NSP01', N'Gà sốt cay',70000, 60000,N'Thịt gà sốt cay đặc biệt với công thức của Thái, khẩu phần 2 người ăn',1,'ga_sot_cay.jpg',1),
	('SP06', 'NSP02', N'Hamburger bò',70000,65000, N'Hamburger bò kết hợp salad rau củ,khẩu phần 1 người ăn',1,'hamburger_bo.jpg',1),
	('SP07', 'NSP02', N'Hamburger cá ngừ',80000,75000, N'Hamburger cá ngừ kết hợp sốt chanh, khẩu phần 1 người ăn',1,'hamburger_ca_ngu.jpg',1),
	('SP08', 'NSP03', N'Bánh mì kẹp thịt',40000,30000,N'Bánh mì kèp thịt nướng, khẩu phần 1 người ăn', 1,'banh_mi_kep_thit.jpg',1),
	('SP09', 'NSP03', N'Bánh mì kẹp xúc xích',30000,25000,N'Bánh mì kèp xúc xích heo, khẩu phần 1 người ăn',1, 'banh_mi_kep_xuc_xich.jpg',1),
	('SP10', 'NSP04', N'Pizza phô mai',70000,50000,N'Pizza béo ngậy của vị phô mai, khẩu phần 2 người ăn', 1,'pizza_pho_mai.jpg',1),
	('SP11', 'NSP04', N'Pizza hải sản',120000,100000, N'Pizza tôm và mực tươi, khẩu phần 4 người ăn',1,'pizza_hai_san.jpg',1),
	('SP12', 'NSP04', N'Pizza nấm',85000, 80000,N'Pizza nấm kim châm, khẩu phần 4 người ăn',1,'pizza_nam.jpg',1),
	('SP13', 'NSP04', N'Pizza xúc xích',95000, 90000,N'Pizza xúc xích nướng, khẩu phần 4 người ăn',1,'pizza_xuc_xich.jpg',1),
	('SP14', 'NSP05', N'Sandwich gà',35000,32000,N'Bánh sandwich gà chà bông, khẩu phần 1 người ăn', 1,'sandwich_ga.jpg',1),
	('SP15', 'NSP05', N'Sandwich thịt thăn',40000,35000,N'Sanwich thịt thăn bò, khẩu phần 1 người ăn', 1,'sandwich_thit_than.jpg',1),
	('SP16', 'NSP05', N'Sandwich trứng phô mai',20000,20000,N'Sanwich trứng rán phô mai, khẩu phần 1 người ăn', 1,'sandwich_trung_pho_mai.jpg',1),
	('SP17', 'NSP06', N'Spaghetti sốt cà chua bò',55000,45000,N'Spaghetti sốt cà chưa, khẩu phần 1 người ăn',1,'spaghetti_sot_ca_chua_bo_bam.jpg',1),
	('SP18', 'NSP06', N'Spaghetti sốt kem',50000,45000,N'Spaghetit sốt kem tươi kết hợp với oliu, khẩu phần 1 người ăn',1,'spaghetti_sot_kem.jpg',1),
	('SP19', 'NSP07', N'Xúc xích',20000,18000, N'Xúc xích nướng, khẩu phần 2 người ăn',1,'xuc_xich.jpg',1),
	('SP20', 'NSP09', N'Khoai tây chiên',35000,32000,N'Khoai tây chiên bơ, khẩu phần 4 người ăn',1,'khoai_tay_chien.jpg',1),
	('SP21', 'NSP10', N'Hành tây chiên',30000,28000,N'Hành tây chiên giòn, khẩu phần 1 người ăn', 1,'hanh_tay_chien.jpg',1),
	('SP22', 'NSP08', N'Sprite',15000, 13000,N'Nước có ga',1,'sprite.jpg',1),
	('SP23', 'NSP08', N'Fanta',15000, 13000,N'Nước có ga', 1,'fanta.jpg',1),
	('SP24', 'NSP08', N'Pepsi',15000, 13000,N'Nước có ga',1,'pepsi.jpg',1)


INSERT INTO GIAMGIA
VALUES

	('GG01', 'SP01', 20,'2021-03-08'),
	('GG02', 'SP05', 10,'2021-04-05'),
	('GG03', 'SP09', 25,'2021-03-08'),
	('GG04', 'SP10', 25,'2021-04-05'),
	('GG05', 'SP18', 15,'2021-06-15'),
	('GG06', 'SP12', 20,'2021-02-23'),
	('GG07', 'SP03', 20,'2021-07-22'),
	('GG08', 'SP17', 30,'2021-04-06'),
	('GG09', 'SP24', 30,'2021-02-06'),
	('GG10', 'SP02', 20,'2021-01-30')

INSERT INTO DANHGIA
VALUES
	('DG01','SP01','KH11',5,'2021-2-10',N'Ngon lắm shop ơi. Giao hàng nhanh. Duyệt '),
	('DG02','SP01','KH05',5,'2021-2-14',N'Giao hàng nhanh. Đồ ăn giao còn nóng luôn.'),
	('DG03','SP01','KH15',5,'2021-2-24',N'Ngon lắm nha, hương vị đặc biệt lắm luôn á'),
	('DG04','SP02','KH17',5,'2021-2-17',N'gà rán tuyệt vời lắm luôn, rất giòn, hàng giao còn nóng luôn nha'),
	('DG05','SP02','KH02',5,'2021-2-20',N'ngon lắm , cho 5 sao'),
	('DG06','SP03','KH20',5,'2021-2-11',N'đùi gà ngon lắm luôn, giao hàng lúc còn nóng'),
	('DG07','SP03','KH23',5,'2021-2-15',N'5 sao'),
	('DG08','SP04','KH03',5,'2021-2-6',N'Ngon lắm nha , cho món này 5 sao'),
	('DG09','SP04','KH19',5,'2021-2-10',N'cũng được, chưa bằng mẹ tui nấu.'),
	('DG10','SP04','KH14',5,'2021-3-6',N'Ngon lắm nha, 5s '),
	('DG11','SP05','KH24',5,'2021-2-19',N'Ngon lắm shop ơi, cay đã lắm luôn'),
	('DG12','SP05','KH09',5,'2021-2-25',N'Ngon nhưng mà cay quá huhuh.'),
	('DG13','SP05','KH01',3.5,'2021-3-5',N'cay quá rồi, ăn hỏng nổi luôn á'),
	('DG14','SP06','KH26',5,'2021-3-1',N'ngon, giao nhanh , 5s'),
	('DG15','SP07','KH29',4.5,'2021-2-20',N'món này chưa ok lắm, cá còn hơi tanh tanh'),
	('DG16','SP08','KH22',3,'2021-3-7',N'bánh mì nướng quá giòn rồi, nướng hết thơm luôn'),
	('DG17','SP09','KH08',5,'2021-3-10',N'ngon nè, xúc xích vị gì đặc biệt quá vậy shop ?'),
	('DG18','SP10','KH30',3,'2021-3-2',N'món này béo quá @@ '),
	('DG19','SP11','KH27',5,'2021-2-15',N'Ngon lắm shop ơi hải sản tươi quá '),
	('DG20','SP11','KH05',5,'2021-2-20',N'ùi ui ngon quá shop'),
	('DG21','SP11','KH15',5,'2021-2-26',N'món này ngon quá, 5s '),
	('DG22','SP12','KH04',4.5,'2021-3-6',N'sao shop giao cho mình pizza hơi cháy. nhưng mà tại ngon nên cho 4.5 thôi '),
	('DG23','SP13','KH24',5,'2021-2-20',N'ngon lắm, 5s'),
	('DG24','SP14','KH02',5,'2021-4-6',N'ngon, giao hành cực nhanh'),
	('DG25','SP15','KH26',5,'2021-3-22',N'giao hành nhanh, 5sao'),
	('DG26','SP19','KH30',5,'2021-3-26',N'xúc xích này shop làm hay mua ở đâu mà ngon quá vậy ?'),
	('DG27','SP24','KH28',5,'2021-3-11',N'giòn lắm, giao hàng lúc còn nóng luôn'),
	('DG28','SP21','KH16',5,'2021-3-13',N'món này lạ miệng quá shop, 5s'),
	('DG29','SP23','KH27',3.5,'2021-3-15',N'không ngon, cảm giác như hành phi lên rồi ăn với gia vị '),
	('DG30','SP24','KH07',4.5,'2021-4-3',N'Ngon, vị lạ, hơi khét')

INSERT INTO CHITIET_DONHANG
VALUES 
	('HD001','SP02',5,30000),
	('HD001','SP03',5,35000),
	('HD001','SP21',5,15000),
	('HD002','SP01',1,30000),
	('HD002','SP05',1,70000),
	('HD002','SP21',2,15000),
	('HD003','SP01',2,30000),
	('HD003','SP09',2,30000),
	('HD003','SP11',1,120000),
	('HD003','SP20',1,30000),
	('HD003','SP24',5,35000),
	('HD004','SP01',2,30000),
	('HD004','SP02',2,35000),
	('HD004','SP06',1,70000),
	('HD004','SP13',1,95000),
	('HD004','SP24',4,35000),
	('HD004','SP20',1,30000),
	('HD004','SP21',5,15000),
	('HD004','SP22',5,15000),
	('HD005','SP17',1,55000),
	('HD005','SP03',1,30000),
	('HD005','SP21',1,15000),
	('HD006','SP08',5,40000),
	('HD006','SP17',1,55000),
	('HD006','SP19',5,20000),
	('HD006','SP14',3,35000),
	('HD007','SP10',1,70000),
	('HD007','SP11',1,120000),
	('HD007','SP12',1,85000),
	('HD007','SP14',1,35000),
	('HD007','SP21',7,15000),
	('HD007','SP24',2,35000),
	('HD008','SP03',2,30000),
	('HD008','SP05',1,70000),
	('HD008','SP20',3,30000),
	('HD008','SP22',5,15000),
	('HD009','SP03',1,30000),
	('HD009','SP17',1,55000),
	('HD009','SP24',1,35000),
	('HD010','SP05',1,70000),
	('HD010','SP10',1,70000),
	('HD010','SP18',1,50000),
	('HD010','SP20',1,15000),
	('HD011','SP01',5,30000),
	('HD011','SP05',1,70000),
	('HD011','SP10',1,70000),
	('HD011','SP24',2,35000),
	('HD012','SP11',2,120000),
	('HD012','SP21',5,15000),
	('HD012','SP24',2,35000),
	('HD013','SP03',2,30000),
	('HD013','SP05',1,70000),	
	('HD013','SP06',3,70000),
	('HD014','SP05',2,70000),
	('HD014','SP10',2,70000),
	('HD014','SP21',3,15000),
	('HD015','SP05',1,70000),
	('HD015','SP10',1,70000),
	('HD015','SP17',1,55000),
	('HD015','SP21',5,15000)
