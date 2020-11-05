DROP TABLE CATEGORY CASCADE CONSTRAINTS PURGE;
DROP TABLE CURRENCY CASCADE CONSTRAINTS PURGE;
DROP TABLE CUSTOMER CASCADE CONSTRAINTS PURGE;
DROP TABLE D_DELIVERY_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE D_INVOICE CASCADE CONSTRAINTS PURGE;
DROP TABLE D_PURCHASE_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE D_PURCHASE_INVOICE CASCADE CONSTRAINTS PURGE;
DROP TABLE D_SALES_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE D_STOCK_ISSUE CASCADE CONSTRAINTS PURGE;
DROP TABLE GUDANG CASCADE CONSTRAINTS PURGE;
DROP TABLE H_DELIVERY_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE H_INVOICE CASCADE CONSTRAINTS PURGE;
DROP TABLE H_PURCHASE_INVOICE CASCADE CONSTRAINTS PURGE;
DROP TABLE H_PURCHASE_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE H_SALES_ORDER CASCADE CONSTRAINTS PURGE;
DROP TABLE H_STOCK_ISSUE CASCADE CONSTRAINTS PURGE;
DROP TABLE ITEM CASCADE CONSTRAINTS PURGE;
DROP TABLE JABATAN CASCADE CONSTRAINTS PURGE;
DROP TABLE STAFF CASCADE CONSTRAINTS PURGE;
DROP TABLE SUPPLIER CASCADE CONSTRAINTS PURGE;
DROP TABLE EKSPEDISI CASCADE CONSTRAINTS PURGE;


CREATE TABLE EKSPEDISI
(
	ID_EKSPEDISI VARCHAR(5) PRIMARY KEY,
	NAMA_EKSPEDISI VARCHAR2(255) NOT NULL,
	ALAMAT_EKSPEDISI VARCHAR2(255) NOT NULL,
	CP_EKSPEDISI VARCHAR2(50) NOT NULL,
	NO_TELP NUMBER(20) NOT NULL
);

create table CURRENCY
(
   ID_CURRENCY          VARCHAR2(3)          not null,
   NAMA_CURRENCY        VARCHAR2(255)        not null,
   RATE                 INTEGER            not null,
   constraint PK_CURRENCY primary key (ID_CURRENCY)
);

create table JABATAN 
(
   ID_JABATAN           NUMBER(1)            not null,
   NM_JABATAN           VARCHAR2(255)        not null,
   constraint PK_JABATAN primary key (ID_JABATAN)
);

create table CATEGORY 
(
   ID_CATEGORY          VARCHAR2(3)          not null,
   NAMA_CATEGORY        VARCHAR2(255)        not null,
   constraint PK_CATEGORY primary key (ID_CATEGORY)
);

create table CUSTOMER 
(
   ID_CUSTOMER          VARCHAR2(5)          not null,
   NAMA_CUSTOMER        VARCHAR2(255)        not null,
   ALAMAT_CUSTOMER      VARCHAR2(255)        not null,
   NO_TELP_CUSTOMER     NUMBER(12)           not null,
   EMAIL_CUSTOMER       VARCHAR2(255)        not null,
   constraint PK_CUSTOMER primary key (ID_CUSTOMER)
);

create table GUDANG 
(
   ID_GUDANG            VARCHAR2(5)          not null,
   NAMA_GUDANG          VARCHAR2(255)        not null,
   ALAMAT_GUDANG        VARCHAR2(255)        not null,
   NO_TELP_GUDANG       NUMBER(12)           not null,
   constraint PK_GUDANG primary key (ID_GUDANG)
);

create table SUPPLIER 
(
   ID_SUPPLIER          VARCHAR2(5)          not null,
   NAMA_SUPPLIER        VARCHAR2(255)        not null,
   ALAMAT_SUPPLIER      VARCHAR2(255)        not null,
   PROVINSI_SUPPLIER     VARCHAR2(255)        not null,
   NO_TELP_SUPPLIER     NUMBER(12)           not null,
   EMAIL_SUPPLIER       VARCHAR2(255)        not null,
   constraint PK_SUPPLIER primary key (ID_SUPPLIER)
);

create table STAFF 
(
   ID_STAFF             VARCHAR2(5)          not null,
   ID_JABATAN           NUMBER(1)            not null,
   NAMA_STAFF           VARCHAR2(255)        not null,
   USERNAME_STAFF       VARCHAR2(255)        not null,
   PASSWORD_STAFF       VARCHAR2(255)        not null,
   TGL_LAHIR_STAFF      DATE                 not null,
   ALAMAT_STAFF         VARCHAR2(255)        not null,
   NOMER_TELP_STAFF     NUMBER(12)           not null,
   TGL_MASUK            DATE                 not null,
   EMAIL_STAFF          VARCHAR2(255)        not null,
   constraint PK_STAFF primary key (ID_STAFF)
);

create table ITEM 
(
   ID_ITEM              VARCHAR2(5)          not null,
   ID_CATEGORY          VARCHAR2(3)          not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   NAMA_ITEM            VARCHAR2(255)        not null,
   STOK_ITEM            NUMBER(11)           not null,
   SATUAN_ITEM          VARCHAR2(10)         not null,
   HARGA_JUAL_ITEM      INTEGER              not null,
   HARGA_BELI_ITEM      INTEGER              not null,
   BERAT_ITEM           INTEGER              not null,
   PANJANG_ITEM         INTEGER              not null,
   TINGGI_ITEM          INTEGER              not null,
   LEBAR_ITEM           INTEGER              not null,
   KADAR_AIR_ITEM       NUMBER(3)            not null,
   BALANCE_COST         INTEGER              not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   constraint PK_ITEM primary key (ID_ITEM)
);

create table H_SALES_ORDER 
(
   ID_SALES_ORDER       VARCHAR2(12)         not null,
   ID_DELIVERY_ORDER    VARCHAR2(12)         not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   ID_STAFF             VARCHAR2(5)          not null,
   ID_CUSTOMER          VARCHAR2(5)          not null,
   ID_INVOICE           VARCHAR2(12)         not null,
   NAMA_CUSTOMER        VARCHAR2(255)        not null,
   ALAMAT_CUSTOMER      VARCHAR2(255)        not null,
   TGL_SALES_ORDER      DATE                 not null,
   CREDIT_TERM_SALES_ORDER INTEGER              not null,
   SHIP_VIA             VARCHAR2(255)        not null,
   CURRENCY_SALES_ORDER VARCHAR2(3)        not null,
   RATE                 INTEGER            not null,
   TOTAL                INTEGER              not null,
   TOTAL_PPN            INTEGER              not null,
   TOTAL_HARGA          INTEGER              not null,
   TOTAL_HARGA_CONVERT  INTEGER              not null,
   constraint PK_H_SALES_ORDER primary key (ID_SALES_ORDER)
);

create table D_SALES_ORDER 
(
   ID_ITEM              VARCHAR2(5)          not null,
   ID_SALES_ORDER       VARCHAR2(12)         not null,
   NAMA_ITEM            VARCHAR2(255)        not null,
   QTY_ITEM             INTEGER              not null,
   JENIS_SATUAN         VARCHAR2(10)         not null,
   HARGA_SATUAN         INTEGER              not null,
   BERAT_TOTAL          INTEGER              not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   DISCOUNT             INTEGER              not null,
   SUBTOTAL             INTEGER              not null,
   constraint PK_D_SALES_ORDER primary key (ID_ITEM, ID_SALES_ORDER)
);

create table H_DELIVERY_ORDER 
(
   ID_DELIVERY_ORDER    VARCHAR2(12)         not null,
   ID_CUSTOMER          VARCHAR2(5)          not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   ID_STAFF             VARCHAR2(5)          not null,
   NAMA_CUSTOMER        VARCHAR2(255)        not null,
   ALAMAT_CUSTOMER      VARCHAR2(255)        not null,
   TGL_DELIVERY_ORDER   DATE                 not null,
   CREDIT_TERM_DELIVERY_ORDER INTEGER        not null,
   SHIP_VIA             VARCHAR2(255)        not null,
   CURRENCY_DELIVERY_ORDER VARCHAR2(3)       not null,
   RATE                 INTEGER              not null,
   TOTAL                INTEGER              not null,
   TOTAL_PPN            INTEGER              not null,
   TOTAL_HARGA          INTEGER              not null,
   TOTAL_HARGA_CONVERT  INTEGER              not null,
   constraint PK_DELIVERY_ORDER primary key (ID_DELIVERY_ORDER)
);

create table D_DELIVERY_ORDER 
(
   ID_ITEM              VARCHAR2(5)          not null,
   ID_SALES_ORDER       VARCHAR2(12)         not null,
   ID_DELIVERY_ORDER    VARCHAR2(12)         not null,
   NAMA_ITEM            VARCHAR2(255)        not null,
   QTY_ITEM             INTEGER              not null,
   JENIS_SATUAN         VARCHAR2(10)         not null,
   HARGA_SATUAN         INTEGER              not null,
   BERAT_TOTAL          INTEGER              not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   DISCOUNT             INTEGER              not null,
   SUBTOTAL             INTEGER              not null,
   constraint PK_D_DELIVERY_ORDER primary key (ID_ITEM, ID_SALES_ORDER, ID_DELIVERY_ORDER)
);

create table H_INVOICE 
(
   ID_INVOICE           VARCHAR2(12)         not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   ID_CUSTOMER          VARCHAR2(5)          not null,
   ID_STAFF             VARCHAR2(5)          not null,
   NAMA_CUSTOMER        VARCHAR2(255)        not null,
   ALAMAT_CUSTOMER      VARCHAR2(255)        not null,
   TGL_INVOICE          DATE                 not null,
   CREDIT_TERM_INVOICE  INTEGER              not null,
   SHIP_VIA             VARCHAR2(255)        not null,
   CURRENCY_DELIVERY_ORDER VARCHAR2(3)       not null,
   RATE                 INTEGER              not null,
   TOTAL                INTEGER              not null,
   TOTAL_PPN            INTEGER              not null,
   TOTAL_HARGA          INTEGER              not null,
   TOTAL_HARGA_CONVERT  INTEGER              not null,
   constraint PK_INVOICE primary key (ID_INVOICE)
);

create table D_INVOICE 
(
   ID_ITEM              VARCHAR2(5)          not null,
   ID_SALES_ORDER       VARCHAR2(12)         not null,
   ID_INVOICE           VARCHAR2(12)         not null,
   NAMA_ITEM            VARCHAR2(255),
   QTY_ITEM             INTEGER              not null,
   JENIS_SATUAN         VARCHAR2(10)         not null,
   HARGA_SATUAN         INTEGER              not null,
   BERAT_TOTAL          INTEGER              not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   DISCOUNT             INTEGER              not null,
   SUBTOTAL             INTEGER              not null,
   constraint PK_D_INVOICE primary key (ID_ITEM, ID_SALES_ORDER, ID_INVOICE)
);

create table H_PURCHASE_ORDER 
(
   ID_PURCHASE_ORDER    VARCHAR2(12)         not null,
   ID_SUPPLIER          VARCHAR2(5)          not null,
   ID_STAFF             VARCHAR2(5)          not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   NAMA_SUPPLIER        VARCHAR2(255)        not null,
   ALAMAT_SUPPLIER      VARCHAR2(255)        not null,
   TGL_PURCHASE_ORDER   DATE                 not null,
   CREDIT_TERM_PURCHASE_ORDER INTEGER              not null,
   SHIP_VIA             VARCHAR2(255)        not null,
   CURRENCY_PURCHASE_ORDER VARCHAR2(255)        not null,
   RATE                 INTEGER            not null,
   TOTAL                INTEGER              not null,
   TOTAL_PPN            INTEGER              not null,
   TOTAL_HARGA          INTEGER              not null,
   TOTAL_HARGA_CONVERT  INTEGER              not null,
   constraint PK_H_PURCHASE_ORDER primary key (ID_PURCHASE_ORDER)
);

create table D_PURCHASE_ORDER 
(
   ID_ITEM              VARCHAR2(5)          not null,
   ID_PURCHASE_ORDER    VARCHAR2(12)         not null,
   NAMA_ITEM            VARCHAR2(255)          not null,
   QTY_ITEM             INTEGER              not null,
   JENIS_SATUAN         VARCHAR2(10)         not null,
   HARGA_SATUAN         INTEGER              not null,
   DISCOUNT             INTEGER              not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   SUBTOTAL             INTEGER              not null,
   constraint PK_D_PUCHASE_ORDER primary key (ID_ITEM, ID_PURCHASE_ORDER)
);

create table H_PURCHASE_INVOICE 
(
   ID_PURCHASE_INVOICE  VARCHAR2(12)         not null,
   ID_SUPPLIER        VARCHAR2(255)        not null,
   ID_GUDANG            VARCHAR2(5)          not null,
   ID_STAFF             VARCHAR2(5)          not null,
   NAMA_SUPPLIER        VARCHAR2(255)        not null,
   ALAMAT_SUPPLIER      VARCHAR2(255)        not null,
   SUPPLIER_ID_INVOICE  VARCHAR2(12)         not null,
   TGL_PURCHASE_INVOICE DATE                 not null,
   CREDIT_TERM_PURCHASE_INVOICE INTEGER                 not null,
   SHIP_VIA             VARCHAR2(255)        not null,
   CURRENCY_PURCHASE_INVOICE VARCHAR2(3)          not null,
   RATE                 FLOAT(11)            not null,
   TOTAL                INTEGER              not null,
   TOTAL_PPN            INTEGER              not null,
   TOTAL_HARGA          INTEGER              not null,
   TOTAL_HARGA_CONVERT  INTEGER              not null,
   constraint PK_H_PURCHASE_INVOICE primary key (ID_PURCHASE_INVOICE)
);

create table D_PURCHASE_INVOICE 
(
   ID_PURCHASE_INVOICE  VARCHAR2(12)         not null,
   ID_ITEM              VARCHAR2(5)          not null,
   NAMA_ITEM            VARCHAR2(255)          not null,
   QTY_ITEM             INTEGER              not null,
   JENIS_SATUAN         VARCHAR2(10)         not null,
   HARGA_SATUAN         INTEGER              not null,
   DISCOUNT             INTEGER              not null,
   KADAR_AIR            NUMBER(3)            not null,
   JENIS_PPN            VARCHAR2(3)          not null,
   SUBTOTAL             INTEGER              not null,
   constraint PK_D_PURCHASE_INVOICE primary key (ID_PURCHASE_INVOICE, ID_ITEM)
);
CREATE TABLE H_STOCK_ISSUE
(
	ID_STOCK_ISSUE VARCHAR2(12) NOT NULL,
   ID_STAFF VARCHAR2(5) NOT NULL,
	DESK_STOCK_ISSUE VARCHAR2(255) NOT NULL,
	TGL_STOCK_ISSUE DATE NOT NULL,
	TOTAL_STOCK_ISSUE INTEGER NOT NULL,
   constraint PK_H_STOCK_ISSUE primary key (ID_STOCK_ISSUE)
);
CREATE TABLE D_STOCK_ISSUE
(
	ID_ITEM VARCHAR2(5) NOT NULL,
	ID_STOCK_ISSUE VARCHAR2(12) NOT NULL,
	NAMA_ITEM VARCHAR2(255) NOT NULL,
	QTY_ITEM INTEGER NOT NULL,
	HARGA_ITEM INTEGER NOT NULL,
	SATUAN_ITEM VARCHAR2(10) NOT NULL,
	SUBTOTAL INTEGER NOT NULL,
	constraint PK_D_STOCK_ISSUE primary key (ID_STOCK_ISSUE,ID_ITEM)
);

CREATE OR REPLACE TRIGGER update_stok_after_si
    AFTER INSERT ON D_STOCK_ISSUE
    FOR EACH ROW 
BEGIN
    UPDATE item
    set stok_item = (stok_item - :NEW.qty_item)
    where id_item = :NEW.id_item;
END;
/

INSERT INTO EKSPEDISI VALUES('TM001','PT. TRANS MANDIRI LOGISTIC','JL. BAWAL NO 23, SURABAYA','NOOR', 082256378471);
INSERT INTO EKSPEDISI VALUES('SL001','PT. SINAR LOGISTIC','JL. KEMBANG KUNING NO 123, SURABAYA','CAHYO', 081132856487);
INSERT INTO EKSPEDISI VALUES('TL002','PT. TRANSPRATAMA LOGISTIC','JL. TANJUNG PERAK NO 201-206, SURABAYA','ARIF', 085968741264);
INSERT INTO EKSPEDISI VALUES('LM001','PT. LANCAR MAJU BERSAMA','JL. TANJUNG PERAK BARAT NO 1-4, SURABAYA','CHANDRA', 082154876987);
INSERT INTO EKSPEDISI VALUES('PI001','PT. PRATAMA INDO LOGISTIC','JL. MANYAR KERTOARJO NO 7, SURABAYA','ALIF', 085789478552);

insert into JABATAN values (1, 'Admin Gudang');
insert into JABATAN values (2, 'Admin Penjualan');
insert into JABATAN values (3, 'Admin Pembelian');
insert into JABATAN values (4, 'Admin Akutansi');
insert into JABATAN values (5, 'Sales');

insert into STAFF values('AM001', 1, 'Amadeo Maheswara', 'amadeo', 'amadeo', sysdate, 'Perum Jaga Tikus F6/29', 081234567890, sysdate, 'amadeoganteng@gmail.com');
insert into STAFF values('MA001', 2, 'Maikel Anjayani', 'maikel', 'anjayani', sysdate, 'Apartemen Gaji Buta, Rungkut Kidul', 087654321234, sysdate, 'maikeljelek@gmail.com');
insert into STAFF values('MT001', 3, 'Melvern Tallall', 'melvern', 'tallall', sysdate, 'Jalan Buaya Darat no 1', 089098765432, sysdate, 'melvernpakboi@gmail.com');
insert into STAFF values('BH001', 4, 'Brian Horizon', 'brian', 'yahoo', sysdate, 'Jalan Setan gg Buntu no 35', 089012345678, sysdate, 'briansiluman@gmail.com');
insert into STAFF values('VC001', 5, 'Valkrie Camiela', 'valk', 'cam321', sysdate, 'Perum Tersembunyi Blok A3/69', 087765432112, sysdate, 'valkcam@gmail.com');
insert into STAFF values('NR001', 5, 'Natural Regina', 'natural', 'regin123', sysdate, 'Perum Green House Blok F6/12', 081716151413, sysdate, 'nregin@gmail.com');

insert into SUPPLIER values('JT001', 'PT. Maju Kena Mundur Kena', 'Jalan Uninstall Windows no 25', 'Jawa Timur', 089127436461, 'ptmajumundur@yahoo.com');
insert into SUPPLIER values('BA001', 'PT. Muter Muter Pusing', 'Jalan Yamisok Mahal no 89', 'Bali', 087137154712, 'ptmutermuter@gmail.com');
insert into SUPPLIER values('JB001', 'PT. Kanan Kiri Sama Saja', 'Jalan Petrik Setar no 27', 'Jawa Barat', 083423424874, 'ptkanankiri@yahoo.com');
insert into SUPPLIER values('JT002', 'PT. Naik Turun Aja', 'Jalan MumboWumbo no 768', 'Jawa Tengah', 082978341728, 'ptnaikturun@gmail.com');

insert into GUDANG values('GB001', 'Gudang Besar', 'Jalan Gibah Santuy no 69', 081286323486);
insert into GUDANG values('GK001', 'Gudang Kecil', 'Jalan In Aja Dulu no 28', 081372647643);
insert into GUDANG values('GU001', 'Gudang Utama', 'Jalan Sama Aku Aja no 13', 083246856583);

insert into h_sales_order values ('12346', '-', 'GB001', 'NR001', 'MO001', '-', 'Mang Oleh', 'Jalan Bandung Selatan no 15', sysdate, 21, 'TM001', 'IDR', 1, 123, 123);
insert into d_sales_order values ('KK001', '12346', 'Keripik Kentang Original', 12, 'BOX', 1234, 234, 'EXC', 3, 12345, 123456);
insert into d_sales_order values ('0M001', '12346', 'Odading Mang Oleh', 12, 'BOX', 123, 234, 'EXC', 3, 12345, 123456);

insert into h_sales_order values ('12347', '-', 'GB001', 'NR001', 'MO001', '-', 'Mang Oleh', 'Jalan Bandung Selatan no 15', sysdate, 21, 'TM001', 'IDR', 1, 123, 123);
insert into d_sales_order values ('JL001', '12347', 'Jus Lemon Segar', 12, 'BOX', 1234, 234, 'EXC', 3, 12345, 123456);

insert into h_sales_order values ('12348', '-', 'GK001', 'NR001', 'MK001', '-', 'Manusia Karet', 'Jalan Bandung Selatan no 15', sysdate, 21, 'TM001', 'IDR', 1, 123, 123);
insert into d_sales_order values ('KK001', '12348', 'Keripik Kentang Original', 24, 'BOX', 1234, 234, 'EXC', 3, 12345, 123456);
insert into d_sales_order values ('0M001', '12348', 'Odading Mang Oleh', 24, 'BOX', 123, 234, 'EXC', 3, 12345, 123456);

insert into CATEGORY values('M01', 'Makanan');
insert into CATEGORY values('M02', 'Minuman');
insert into CATEGORY values('M03', 'Mainan');
insert into CATEGORY values('P01', 'Pakaian');
insert into CATEGORY values('E01', 'Elektronik');

insert into ITEM values('KK001', 'M01', 'GU001', 'Keripik Kentang Original', 5000, 'BOX', 65000, 50000, 2250, 60, 30, 30, 0, 5000*50000, 'INC');
insert into ITEM values('OM001', 'M01', 'GU001', 'Odading Mang Oleh', 5000, 'BOX', 130000, 115250, 3250, 75, 37, 34, 0, 5000*115250, 'EXC');
insert into ITEM values('JL001', 'M02', 'GU001', 'Jus Lemon Segar', 7500, 'BOX', 85000, 70000, 1875, 60, 26, 37, 100, 7500*70000, 'INC');
insert into ITEM values('JT001', 'M02', 'GU001', 'Jus Tomat Enak', 9500, 'BOX', 60000, 55000, 2550, 85, 30, 47, 100, 9500*55000, 'INC');
insert into ITEM values('BK001', 'M03', 'GK001', 'Boneka Key2', 15000, 'PIECE', 275000, 250000, 4500, 28, 36, 28, 0, 15000*250000, 'EXC');
insert into ITEM values('GA001', 'M03', 'GK001', 'Gundam Anjayani', 9000, 'PIECE', 90000, 78000, 5000, 138, 38, 36, 0, 9000*78000, 'INC');
insert into ITEM values('KI001', 'P01', 'GK001', 'Kostum Iron Man Mang Oleh', 12000, 'PIECE', 250000, 185000, 250, 10, 15, 1, 0, 12000*250000, 'INC');
insert into ITEM values('BH001', 'P01', 'GK001', 'Baju Harley Kuning', 5600, 'PIECE',150000, 89000, 275, 10, 15, 1, 0, 5600*89000, 'EXC');
insert into ITEM values('LP001', 'E01', 'GB001', 'Logitooth Pro X', 3500, 'PIECE', 1250000, 850000, 1000, 33, 2, 10, 0, 3500*1250000, 'INC');
insert into ITEM values('SA001', 'E01', 'GB001', 'StilSeris Aktris 1', 5000, 'PIECE', 1100000, 600000, 450, 24, 7, 13, 0, 5000*600000, 'EXC');

insert into CUSTOMER values('MO001', 'Mang Oleh', 'Jalan Bandung Selatan no 15', 081894367328, 'odadingenak@oleh.com');
insert into CUSTOMER values('MK001', 'Manusia Karet', 'Jalan Anjayani IV no 65', 088265349876, 'lutfionepiece@gmail.com');
insert into CUSTOMER values('IJ001', 'Invisible John', 'Perum WWA Cluster SmackDown no 48', 082853463821, 'iaminvisible@yahoo.com');
insert into CUSTOMER values('DI001', 'Dea Impostor', 'Jalan Ventilasi no 13', 087123564889, 'fitnahenak@gmail.com');
insert into CUSTOMER values('BC001', 'Bambank Crewmate', 'Perum Mirahq Cluster Cafetaria no 2', 089396467124, 'donttrustanybody@gmail.com');

insert into CURRENCY values('IDR', 'Indonesia Rupiah', 1);
insert into CURRENCY values('CNY', 'Chinese Yuan', 2190);
insert into CURRENCY values('EUR', 'Euro', 17190);
insert into CURRENCY values('HKD', 'Hong Kong Dollar', 1893);
insert into CURRENCY values('INR', 'Indian Rupee', 200);
insert into CURRENCY values('JPY', 'Japanese Yen', 139);
insert into CURRENCY values('MYR', 'Malaysian Ringgit', 3534);
insert into CURRENCY values('USD', 'US Dollar', 14670);
insert into CURRENCY values('SGD', 'Singapore Dollar', 10796);
insert into CURRENCY values('TWD', 'Yaiwan Dollar', 510);


commit;