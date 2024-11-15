-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.40 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for minimarket
DROP DATABASE IF EXISTS `minimarket`;
CREATE DATABASE IF NOT EXISTS `minimarket` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `minimarket`;

-- Dumping structure for table minimarket.barang
DROP TABLE IF EXISTS `barang`;
CREATE TABLE IF NOT EXISTS `barang` (
  `id_barang` int NOT NULL AUTO_INCREMENT,
  `id_suplier` int DEFAULT NULL,
  `id_satuan` int DEFAULT NULL,
  `barcode` varchar(254) NOT NULL,
  `nama_barang` varchar(50) DEFAULT NULL,
  `harga_beli` int NOT NULL DEFAULT '0',
  `ppn` float NOT NULL DEFAULT '0',
  `discount` float NOT NULL DEFAULT '0',
  `harga_beli_netto` int NOT NULL DEFAULT '0',
  `stok_display` int NOT NULL DEFAULT '0',
  `stok_gudang` int NOT NULL DEFAULT '0',
  `harga_jual1` int NOT NULL DEFAULT '0',
  `harga_jual2` int NOT NULL DEFAULT '0',
  `harga_jual3` int NOT NULL DEFAULT '0',
  `harga_jual4` int NOT NULL DEFAULT '0',
  `qty2` int NOT NULL DEFAULT '0',
  `qty3` int NOT NULL DEFAULT '0',
  `qty4` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_barang`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.barang: ~8 rows (approximately)
INSERT IGNORE INTO `barang` (`id_barang`, `id_suplier`, `id_satuan`, `barcode`, `nama_barang`, `harga_beli`, `ppn`, `discount`, `harga_beli_netto`, `stok_display`, `stok_gudang`, `harga_jual1`, `harga_jual2`, `harga_jual3`, `harga_jual4`, `qty2`, `qty3`, `qty4`) VALUES
	(1, 2, 1, '8992696407688', 'Nestle 700g', 2500, 11, 0.5, 0, 58, 57, 3386, 3372, 3316, 3191, 3, 6, 9),
	(2, 2, 1, '896867700326', 'Le Minerale', 2000, 11, 0, 2220, 28, 61, 2600, 2300, 2270, 2264, 3, 8, 12),
	(3, 3, 1, '7237844127560', 'Pempers Sensi', 3000, 0, 0, 3000, 27, 50, 3550, 3530, 3520, 3510, 5, 10, 15),
	(4, 2, 3, '8992112011017', 'Cerebrovot1', 4000, 0, 0, 0, 12, 80, 4500, 4400, 4300, 4200, 2, 6, 10),
	(5, 4, 4, '1234', 'Aqua Sedang1', 7000, 0, 0, 7000, 0, 36, 9100, 8400, 7700, 7350, 10, 20, 30),
	(12, 1, 1, '445566', 'barang baru dateng', 1000, 0, 0, 1000, 0, 95, 5000, 4000, 3000, 2000, 3, 4, 3),
	(13, NULL, NULL, '122', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(14, NULL, NULL, '112233', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- Dumping structure for view minimarket.ds_markup
DROP VIEW IF EXISTS `ds_markup`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_markup` (
	`id_pembelian` INT NOT NULL,
	`no_faktur` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`tgl_faktur` DATETIME NOT NULL,
	`id_barang` INT NOT NULL,
	`barcode` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`pembelian_detail.qty` INT NOT NULL,
	`pembelian_detail.price` INT NOT NULL,
	`pembelian_detail.ppn` FLOAT NOT NULL,
	`pembelian_detail.discount` FLOAT NOT NULL,
	`pembelian_detail.price_netto` INT NOT NULL,
	`harga_satuan` INT NOT NULL,
	`profit1` DECIMAL(17,2) NULL,
	`qty2` INT NOT NULL,
	`harga_qty2` INT NOT NULL,
	`profit2` DECIMAL(17,2) NULL,
	`qty3` INT NOT NULL,
	`harga_qty3` INT NOT NULL,
	`profit3` DECIMAL(17,2) NULL,
	`qty4` INT NOT NULL,
	`harga_qty4` INT NOT NULL,
	`profit4` DECIMAL(17,2) NULL,
	`status_pembelian` ENUM('temp','saved','mark_up') NOT NULL COLLATE 'latin1_swedish_ci'
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_report_expiry
DROP VIEW IF EXISTS `ds_report_expiry`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_report_expiry` (
	`id_barang` INT NOT NULL,
	`no_faktur` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`tgl_faktur` DATETIME NOT NULL,
	`expiry` DATE NULL,
	`lama_jatuh_tempo` INT NOT NULL COMMENT 'lama jatuh tempo(hari) berdasarkan tgl faktur',
	`kode_suplier` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`nama_suplier` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`barcode` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`qty` INT NOT NULL,
	`expire_in` INT NULL
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_report_penjualan
DROP VIEW IF EXISTS `ds_report_penjualan`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_report_penjualan` (
	`id_transaksi` INT NOT NULL,
	`waktu` DATETIME NOT NULL,
	`kode_transaksi` VARCHAR(1) NOT NULL COLLATE 'utf8mb4_general_ci',
	`id_kasir` INT NOT NULL,
	`bayar` BIGINT NOT NULL,
	`grand_total` BIGINT NOT NULL,
	`kembalian` BIGINT NOT NULL,
	`status` ENUM('pending','active','void','done','retur') NOT NULL COLLATE 'utf8mb4_general_ci',
	`id_transaksi_detail` INT NULL,
	`barcode` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`qty` INT NULL,
	`harga_beli` INT NULL,
	`harga_jual` INT NULL
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_retur_customer
DROP VIEW IF EXISTS `ds_retur_customer`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_retur_customer` (
	`id_retur_customer` INT NOT NULL,
	`no_transaksi` VARCHAR(1) NULL COLLATE 'utf8mb4_general_ci',
	`id_kasir` INT NULL,
	`nama_kasir` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`id_barang` INT NULL,
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`harga_jual` INT NULL,
	`qty` INT NULL,
	`created_at` TIMESTAMP NULL
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_retur_suplier
DROP VIEW IF EXISTS `ds_retur_suplier`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_retur_suplier` (
	`id_retur_suplier` INT NOT NULL,
	`faktur_retur` VARCHAR(1) NULL COLLATE 'utf8mb4_0900_ai_ci',
	`id_kasir` INT NULL,
	`nama_kasir` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`id_barang` INT NULL,
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`id_suplier` INT NULL,
	`nama_suplier` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`qty` INT NULL,
	`created_at` TIMESTAMP NULL
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_transaksi_pembelian
DROP VIEW IF EXISTS `ds_transaksi_pembelian`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_transaksi_pembelian` (
	`id_pembelian_detail` INT NOT NULL,
	`id_pembelian` INT NOT NULL,
	`no_faktur` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`id_barang` INT NOT NULL,
	`barcode` VARCHAR(1) NOT NULL COLLATE 'latin1_swedish_ci',
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`stok` BIGINT NOT NULL,
	`qty` INT NOT NULL,
	`harga` INT NOT NULL,
	`harga_lama` INT NOT NULL,
	`ppn` FLOAT NOT NULL,
	`ppn_lama` FLOAT NOT NULL,
	`discount` FLOAT NOT NULL,
	`discount_lama` FLOAT NOT NULL,
	`harga_netto` INT NOT NULL,
	`harga_netto_lama` INT NOT NULL,
	`total` BIGINT NOT NULL,
	`expiry` DATE NULL
) ENGINE=MyISAM;

-- Dumping structure for view minimarket.ds_transaksi_penjualan
DROP VIEW IF EXISTS `ds_transaksi_penjualan`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `ds_transaksi_penjualan` (
	`id_transaksi_detail` INT NOT NULL,
	`id_transaksi` INT NOT NULL,
	`no_transaksi` VARCHAR(1) NULL COLLATE 'utf8mb4_general_ci',
	`id_barang` INT NULL,
	`barcode` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`nama_barang` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`id_satuan` INT NULL,
	`nama_satuan` VARCHAR(1) NULL COLLATE 'latin1_swedish_ci',
	`harga` INT NOT NULL,
	`qty` INT NOT NULL,
	`jumlah` BIGINT NOT NULL,
	`stok` BIGINT NULL,
	`updated_at` DATETIME NULL
) ENGINE=MyISAM;

-- Dumping structure for table minimarket.kasir
DROP TABLE IF EXISTS `kasir`;
CREATE TABLE IF NOT EXISTS `kasir` (
  `id_kasir` int NOT NULL AUTO_INCREMENT,
  `nama_kasir` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `type` int NOT NULL COMMENT '1 superadmin, 2 admin, 3 kasir',
  `status` char(20) NOT NULL,
  PRIMARY KEY (`id_kasir`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.kasir: ~3 rows (approximately)
INSERT IGNORE INTO `kasir` (`id_kasir`, `nama_kasir`, `password`, `alamat`, `type`, `status`) VALUES
	(1, 'Umam', '1', 'Sumenep', 1, 'Aktif'),
	(2, 'Fajri', '2', 'Sumenep', 2, 'Aktif'),
	(3, 'delan', '3', 'dsds', 3, 'Aktif');

-- Dumping structure for table minimarket.mutasi
DROP TABLE IF EXISTS `mutasi`;
CREATE TABLE IF NOT EXISTS `mutasi` (
  `id_mutasi` int NOT NULL AUTO_INCREMENT,
  `id_reff` int DEFAULT NULL,
  `type` enum('penjualan','pembelian','bayar_hutang','pengeluaran') COLLATE utf8mb4_general_ci NOT NULL,
  `deskripsi` text COLLATE utf8mb4_general_ci NOT NULL,
  `nominal` int NOT NULL,
  `created_at` datetime NOT NULL,
  PRIMARY KEY (`id_mutasi`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table minimarket.mutasi: ~2 rows (approximately)
INSERT IGNORE INTO `mutasi` (`id_mutasi`, `id_reff`, `type`, `deskripsi`, `nominal`, `created_at`) VALUES
	(34, 87, 'penjualan', 'update RETUR PENJUALAN pada waktu: 09/11/2024 22:22:19', 5000, '2024-11-11 21:07:06'),
	(35, 89, 'penjualan', 'update RETUR PENJUALAN pada waktu: 11/11/2024 21:11:20', 2000, '2024-11-11 21:15:29'),
	(36, 91, 'penjualan', 'PENJUALAN pada waktu: 15/11/2024 18:53:09', 27300, '2024-11-15 18:53:38');

-- Dumping structure for table minimarket.obrolan
DROP TABLE IF EXISTS `obrolan`;
CREATE TABLE IF NOT EXISTS `obrolan` (
  `pesan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.obrolan: ~0 rows (approximately)

-- Dumping structure for table minimarket.pembelian
DROP TABLE IF EXISTS `pembelian`;
CREATE TABLE IF NOT EXISTS `pembelian` (
  `id_pembelian` int NOT NULL AUTO_INCREMENT,
  `no_faktur` varchar(254) NOT NULL,
  `tgl_faktur` datetime NOT NULL,
  `id_supplier` int NOT NULL,
  `id_kasir` int NOT NULL,
  `grand_total` int NOT NULL,
  `metode_pembayaran` enum('tunai','konsinyasi','kredit') NOT NULL DEFAULT 'tunai',
  `lama_jatuh_tempo` int NOT NULL COMMENT 'lama jatuh tempo(hari) berdasarkan tgl faktur',
  `status` enum('temp','saved','mark_up') NOT NULL,
  PRIMARY KEY (`id_pembelian`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.pembelian: ~0 rows (approximately)
INSERT IGNORE INTO `pembelian` (`id_pembelian`, `no_faktur`, `tgl_faktur`, `id_supplier`, `id_kasir`, `grand_total`, `metode_pembayaran`, `lama_jatuh_tempo`, `status`) VALUES
	(27, '', '2024-11-09 14:41:39', 0, 1, 0, 'tunai', 0, 'temp');

-- Dumping structure for table minimarket.pembelian_detail
DROP TABLE IF EXISTS `pembelian_detail`;
CREATE TABLE IF NOT EXISTS `pembelian_detail` (
  `id_pembelian_detail` int NOT NULL AUTO_INCREMENT,
  `id_pembelian` int NOT NULL,
  `id_barang` int NOT NULL,
  `qty` int NOT NULL,
  `price` int NOT NULL,
  `ppn` float NOT NULL,
  `discount` float NOT NULL,
  `price_netto` int NOT NULL,
  `expiry` date DEFAULT NULL,
  `qty_return` int NOT NULL DEFAULT '0',
  `status_return` enum('return','active') COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'active',
  PRIMARY KEY (`id_pembelian_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table minimarket.pembelian_detail: ~1 rows (approximately)
INSERT IGNORE INTO `pembelian_detail` (`id_pembelian_detail`, `id_pembelian`, `id_barang`, `qty`, `price`, `ppn`, `discount`, `price_netto`, `expiry`, `qty_return`, `status_return`) VALUES
	(29, 27, 5, 1, 7000, 0, 0, 7000, NULL, 0, 'active');

-- Dumping structure for table minimarket.retur_customer
DROP TABLE IF EXISTS `retur_customer`;
CREATE TABLE IF NOT EXISTS `retur_customer` (
  `id_retur_customer` int NOT NULL AUTO_INCREMENT,
  `id_kasir` int DEFAULT '0',
  `id_transaksi` int DEFAULT '0',
  `id_barang` int DEFAULT '0',
  `harga_jual` int DEFAULT '0',
  `qty` int DEFAULT '0',
  `created_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_retur_customer`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table minimarket.retur_customer: ~0 rows (approximately)
INSERT IGNORE INTO `retur_customer` (`id_retur_customer`, `id_kasir`, `id_transaksi`, `id_barang`, `harga_jual`, `qty`, `created_at`) VALUES
	(2, 1, 89, 12, 2000, 1, '2024-11-11 14:15:29');

-- Dumping structure for table minimarket.retur_suplier
DROP TABLE IF EXISTS `retur_suplier`;
CREATE TABLE IF NOT EXISTS `retur_suplier` (
  `id_retur_suplier` int NOT NULL AUTO_INCREMENT,
  `id_suplier` int DEFAULT NULL,
  `id_kasir` int DEFAULT NULL,
  `id_barang` int DEFAULT NULL,
  `qty` int DEFAULT NULL,
  `faktur_retur` varchar(100) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_retur_suplier`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table minimarket.retur_suplier: ~0 rows (approximately)
INSERT IGNORE INTO `retur_suplier` (`id_retur_suplier`, `id_suplier`, `id_kasir`, `id_barang`, `qty`, `faktur_retur`, `created_at`) VALUES
	(1, 1, 1, 12, 1, '3434545', '2024-11-15 08:25:52'),
	(2, NULL, 1, 12, 1, '', '2024-11-15 08:50:11');

-- Dumping structure for table minimarket.satuan
DROP TABLE IF EXISTS `satuan`;
CREATE TABLE IF NOT EXISTS `satuan` (
  `id_satuan` int NOT NULL AUTO_INCREMENT,
  `nama_satuan` varchar(50) NOT NULL,
  PRIMARY KEY (`id_satuan`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.satuan: ~6 rows (approximately)
INSERT IGNORE INTO `satuan` (`id_satuan`, `nama_satuan`) VALUES
	(1, 'PCS'),
	(2, 'Liter'),
	(3, 'Bungkus'),
	(4, 'Galon'),
	(5, 'Kg'),
	(6, 'Kardus');

-- Dumping structure for table minimarket.supplier
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE IF NOT EXISTS `supplier` (
  `id_suplier` int NOT NULL AUTO_INCREMENT,
  `kode_suplier` varchar(100) NOT NULL,
  `nama_suplier` varchar(30) NOT NULL,
  `alamat_suplier` varchar(100) NOT NULL,
  `contact_person` char(14) NOT NULL,
  PRIMARY KEY (`id_suplier`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.supplier: ~4 rows (approximately)
INSERT IGNORE INTO `supplier` (`id_suplier`, `kode_suplier`, `nama_suplier`, `alamat_suplier`, `contact_person`) VALUES
	(1, 'UNLV', 'Unilever Tbk.', 'Surabaya', '021474836478'),
	(2, 'WFD', 'Wings Food', 'Surabaya', '081977878878'),
	(3, 'BTJ', 'Bintang Toedjoe', 'Jakarta', '081939487837'),
	(4, 'DKLC', 'Dua Kelinci', 'Surabaya', '081977878878'),
	(5, 'IDMC', 'indomarco', 'pamekasan', '089898989');

-- Dumping structure for table minimarket.transaksi
DROP TABLE IF EXISTS `transaksi`;
CREATE TABLE IF NOT EXISTS `transaksi` (
  `id_transaksi` int NOT NULL AUTO_INCREMENT,
  `no_transaksi` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `id_kasir` int NOT NULL,
  `waktu` datetime NOT NULL,
  `bayar` bigint NOT NULL,
  `grand_total` bigint NOT NULL,
  `kembalian` bigint NOT NULL,
  `status` enum('pending','active','void','done','retur') COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id_transaksi`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table minimarket.transaksi: ~2 rows (approximately)
INSERT IGNORE INTO `transaksi` (`id_transaksi`, `no_transaksi`, `id_kasir`, `waktu`, `bayar`, `grand_total`, `kembalian`, `status`) VALUES
	(89, '202411112111201', 1, '2024-11-11 21:11:20', 70000, 2000, 19600, 'retur'),
	(90, '202411112112091', 1, '2024-11-11 21:12:09', 0, 0, 0, 'void'),
	(91, '202411151853091', 1, '2024-11-15 18:53:09', 40000, 27300, 12700, 'done'),
	(92, '202411151853381', 1, '2024-11-15 18:53:38', 0, 0, 0, 'void');

-- Dumping structure for table minimarket.transaksi_detail
DROP TABLE IF EXISTS `transaksi_detail`;
CREATE TABLE IF NOT EXISTS `transaksi_detail` (
  `id_transaksi_detail` int NOT NULL AUTO_INCREMENT,
  `id_barang` int NOT NULL,
  `id_transaksi` int NOT NULL,
  `qty` int NOT NULL,
  `harga_beli` int NOT NULL,
  `harga_jual` int NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id_transaksi_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=latin1;

-- Dumping data for table minimarket.transaksi_detail: ~1 rows (approximately)
INSERT IGNORE INTO `transaksi_detail` (`id_transaksi_detail`, `id_barang`, `id_transaksi`, `qty`, `harga_beli`, `harga_jual`, `updated_at`) VALUES
	(127, 5, 89, 4, 7000, 9100, '2024-11-11 21:11:44'),
	(128, 12, 89, 6, 1000, 2000, '2024-11-11 21:11:56'),
	(129, 5, 91, 3, 7000, 9100, '2024-11-15 18:53:24');

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_markup`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `ds_markup` AS select `pembelian`.`id_pembelian` AS `id_pembelian`,`pembelian`.`no_faktur` AS `no_faktur`,`pembelian`.`tgl_faktur` AS `tgl_faktur`,`barang`.`id_barang` AS `id_barang`,`barang`.`barcode` AS `barcode`,`barang`.`nama_barang` AS `nama_barang`,`pembelian_detail`.`qty` AS `pembelian_detail.qty`,`pembelian_detail`.`price` AS `pembelian_detail.price`,`pembelian_detail`.`ppn` AS `pembelian_detail.ppn`,`pembelian_detail`.`discount` AS `pembelian_detail.discount`,`pembelian_detail`.`price_netto` AS `pembelian_detail.price_netto`,`barang`.`harga_jual1` AS `harga_satuan`,round((((`barang`.`harga_jual1` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit1`,`barang`.`qty2` AS `qty2`,`barang`.`harga_jual2` AS `harga_qty2`,round((((`barang`.`harga_jual2` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit2`,`barang`.`qty3` AS `qty3`,`barang`.`harga_jual3` AS `harga_qty3`,round((((`barang`.`harga_jual3` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit3`,`barang`.`qty4` AS `qty4`,`barang`.`harga_jual4` AS `harga_qty4`,round((((`barang`.`harga_jual4` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit4`,`pembelian`.`status` AS `status_pembelian` from ((`pembelian` join `pembelian_detail` on((`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`))) join `barang` on((`pembelian_detail`.`id_barang` = `barang`.`id_barang`))) where (`pembelian`.`status` = 'saved');

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_report_expiry`;
CREATE ALGORITHM=TEMPTABLE SQL SECURITY DEFINER VIEW `ds_report_expiry` AS select `pembelian_detail`.`id_barang` AS `id_barang`,`pembelian`.`no_faktur` AS `no_faktur`,`pembelian`.`tgl_faktur` AS `tgl_faktur`,`pembelian_detail`.`expiry` AS `expiry`,`pembelian`.`lama_jatuh_tempo` AS `lama_jatuh_tempo`,`supplier`.`kode_suplier` AS `kode_suplier`,`supplier`.`nama_suplier` AS `nama_suplier`,`barang`.`barcode` AS `barcode`,`barang`.`nama_barang` AS `nama_barang`,`pembelian_detail`.`qty` AS `qty`,(to_days(`pembelian_detail`.`expiry`) - to_days(now())) AS `expire_in` from (((`pembelian_detail` left join `barang` on((`pembelian_detail`.`id_barang` = `barang`.`id_barang`))) join `pembelian` on((`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`))) join `supplier` on((`supplier`.`id_suplier` = `pembelian`.`id_supplier`))) where (`pembelian_detail`.`status_return` = 'active') order by (to_days(`pembelian_detail`.`expiry`) - to_days(now()));

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_report_penjualan`;
CREATE ALGORITHM=TEMPTABLE SQL SECURITY DEFINER VIEW `ds_report_penjualan` AS select `transaksi`.`id_transaksi` AS `id_transaksi`,`transaksi`.`waktu` AS `waktu`,`transaksi`.`no_transaksi` AS `kode_transaksi`,`transaksi`.`id_kasir` AS `id_kasir`,`transaksi`.`bayar` AS `bayar`,`transaksi`.`grand_total` AS `grand_total`,`transaksi`.`kembalian` AS `kembalian`,`transaksi`.`status` AS `status`,`transaksi_detail`.`id_transaksi_detail` AS `id_transaksi_detail`,`barang`.`barcode` AS `barcode`,`barang`.`nama_barang` AS `nama_barang`,`transaksi_detail`.`qty` AS `qty`,`transaksi_detail`.`harga_beli` AS `harga_beli`,`transaksi_detail`.`harga_jual` AS `harga_jual` from ((`transaksi` left join `transaksi_detail` on((`transaksi_detail`.`id_transaksi` = `transaksi`.`id_transaksi`))) join `barang` on((`transaksi_detail`.`id_barang` = `barang`.`id_barang`))) where ((`transaksi`.`status` = 'done') or (`transaksi`.`status` = 'retur'));

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_retur_customer`;
CREATE ALGORITHM=TEMPTABLE SQL SECURITY DEFINER VIEW `ds_retur_customer` AS select `retur_customer`.`id_retur_customer` AS `id_retur_customer`,`transaksi`.`no_transaksi` AS `no_transaksi`,`kasir`.`id_kasir` AS `id_kasir`,`kasir`.`nama_kasir` AS `nama_kasir`,`barang`.`id_barang` AS `id_barang`,`barang`.`nama_barang` AS `nama_barang`,`retur_customer`.`harga_jual` AS `harga_jual`,`retur_customer`.`qty` AS `qty`,`retur_customer`.`created_at` AS `created_at` from (((`retur_customer` left join `kasir` on((`kasir`.`id_kasir` = `retur_customer`.`id_kasir`))) left join `barang` on((`barang`.`id_barang` = `retur_customer`.`id_barang`))) left join `transaksi` on((`transaksi`.`id_transaksi` = `retur_customer`.`id_transaksi`)));

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_retur_suplier`;
CREATE ALGORITHM=TEMPTABLE SQL SECURITY DEFINER VIEW `ds_retur_suplier` AS select `retur_suplier`.`id_retur_suplier` AS `id_retur_suplier`,`retur_suplier`.`faktur_retur` AS `faktur_retur`,`kasir`.`id_kasir` AS `id_kasir`,`kasir`.`nama_kasir` AS `nama_kasir`,`barang`.`id_barang` AS `id_barang`,`barang`.`nama_barang` AS `nama_barang`,`supplier`.`id_suplier` AS `id_suplier`,`supplier`.`nama_suplier` AS `nama_suplier`,`retur_suplier`.`qty` AS `qty`,`retur_suplier`.`created_at` AS `created_at` from (((`retur_suplier` left join `kasir` on((`kasir`.`id_kasir` = `retur_suplier`.`id_kasir`))) left join `barang` on((`barang`.`id_barang` = `retur_suplier`.`id_barang`))) left join `supplier` on((`retur_suplier`.`id_suplier` = `supplier`.`id_suplier`)));

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_transaksi_pembelian`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `ds_transaksi_pembelian` AS select `pembelian_detail`.`id_pembelian_detail` AS `id_pembelian_detail`,`pembelian`.`id_pembelian` AS `id_pembelian`,`pembelian`.`no_faktur` AS `no_faktur`,`pembelian_detail`.`id_barang` AS `id_barang`,`barang`.`barcode` AS `barcode`,`barang`.`nama_barang` AS `nama_barang`,(`barang`.`stok_display` + `barang`.`stok_gudang`) AS `stok`,`pembelian_detail`.`qty` AS `qty`,`pembelian_detail`.`price` AS `harga`,`barang`.`harga_beli` AS `harga_lama`,`pembelian_detail`.`ppn` AS `ppn`,`barang`.`ppn` AS `ppn_lama`,`pembelian_detail`.`discount` AS `discount`,`barang`.`discount` AS `discount_lama`,`pembelian_detail`.`price_netto` AS `harga_netto`,`barang`.`harga_beli_netto` AS `harga_netto_lama`,(`pembelian_detail`.`qty` * `pembelian_detail`.`price_netto`) AS `total`,`pembelian_detail`.`expiry` AS `expiry` from ((`pembelian` join `pembelian_detail` on((`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`))) join `barang` on((`pembelian_detail`.`id_barang` = `barang`.`id_barang`)));

-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `ds_transaksi_penjualan`;
CREATE ALGORITHM=TEMPTABLE SQL SECURITY DEFINER VIEW `ds_transaksi_penjualan` AS select `transaksi_detail`.`id_transaksi_detail` AS `id_transaksi_detail`,`transaksi_detail`.`id_transaksi` AS `id_transaksi`,`transaksi`.`no_transaksi` AS `no_transaksi`,`barang`.`id_barang` AS `id_barang`,`barang`.`barcode` AS `barcode`,`barang`.`nama_barang` AS `nama_barang`,`satuan`.`id_satuan` AS `id_satuan`,`satuan`.`nama_satuan` AS `nama_satuan`,`transaksi_detail`.`harga_jual` AS `harga`,`transaksi_detail`.`qty` AS `qty`,(`transaksi_detail`.`harga_jual` * `transaksi_detail`.`qty`) AS `jumlah`,(`barang`.`stok_display` + `barang`.`stok_gudang`) AS `stok`,`transaksi_detail`.`updated_at` AS `updated_at` from (((`transaksi_detail` left join `barang` on((`transaksi_detail`.`id_barang` = `barang`.`id_barang`))) left join `transaksi` on((`transaksi_detail`.`id_transaksi` = `transaksi`.`id_transaksi`))) left join `satuan` on((`satuan`.`id_satuan` = `barang`.`id_satuan`))) order by `transaksi_detail`.`updated_at` desc;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
