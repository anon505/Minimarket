-- phpMyAdmin SQL Dump
-- version 3.5.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 01, 2013 at 04:48 PM
-- Server version: 5.5.25a
-- PHP Version: 5.4.4

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `minimarket`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

DROP TABLE IF EXISTS `barang`;
CREATE TABLE IF NOT EXISTS `barang` (
  `id_barang` int(11) NOT NULL AUTO_INCREMENT,
  `id_suplier` int(11) NOT NULL,
  `nama_barang` varchar(50) NOT NULL,
  `harga_beli` int(100) NOT NULL,
  `harga_jual` int(100) NOT NULL,
  `stok` int(30) NOT NULL,
  `satuan` int(11) NOT NULL,
  PRIMARY KEY (`id_barang`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id_barang`, `id_suplier`, `nama_barang`, `harga_beli`, `harga_jual`, `stok`, `satuan`) VALUES
(1, 2, 'Mie Sedaap', 1500, 2000, 100, 3),
(2, 2, 'POP Mie', 4000, 4500, 100, 1),
(3, 3, 'Ciptadent', 1500, 2000, 100, 1),
(4, 2, 'Mama Lime', 5000, 6000, 100, 1),
(5, 4, 'Kacang Garuda', 5000, 6000, 100, 1);

-- --------------------------------------------------------

--
-- Table structure for table `kasir`
--

DROP TABLE IF EXISTS `kasir`;
CREATE TABLE IF NOT EXISTS `kasir` (
  `id_kasir` int(11) NOT NULL AUTO_INCREMENT,
  `nama_kasir` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `type` int(11) NOT NULL,
  `status` char(20) NOT NULL,
  PRIMARY KEY (`id_kasir`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `kasir`
--

INSERT INTO `kasir` (`id_kasir`, `nama_kasir`, `password`, `alamat`, `type`, `status`) VALUES
(1, 'Umam', '1', 'Sumenep', 1, 'Aktif'),
(2, 'Fajri', '2', 'Sumenep', 2, 'Aktif');

-- --------------------------------------------------------

--
-- Stand-in structure for view `keuntungan`
--
DROP VIEW IF EXISTS `keuntungan`;
CREATE TABLE IF NOT EXISTS `keuntungan` (
`id_barang` int(11)
,`nama_barang` varchar(50)
,`waktu beli` datetime
,`harga_beli` int(100)
,`harga_jual` int(100)
,`total` int(30)
,`id_kasir` int(11)
,`nama_satuan` varchar(50)
,`tanggal` date
);
-- --------------------------------------------------------

--
-- Table structure for table `obrolan`
--

DROP TABLE IF EXISTS `obrolan`;
CREATE TABLE IF NOT EXISTS `obrolan` (
  `pesan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `obrolan`
--



-- --------------------------------------------------------

--
-- Table structure for table `pembelian`
--

DROP TABLE IF EXISTS `pembelian`;
CREATE TABLE IF NOT EXISTS `pembelian` (
  `id_barang` int(11) NOT NULL,
  `id_kasir` int(11) NOT NULL,
  `tgl_pembelian` datetime NOT NULL,
  `jumlah` int(30) NOT NULL,
  `status` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `pembelian`
--
DROP TRIGGER IF EXISTS `updatestokbeli`;
DELIMITER //
CREATE TRIGGER `updatestokbeli` AFTER INSERT ON `pembelian`
 FOR EACH ROW begin update barang set stok=stok+new.jumlah where id_barang=NEW.id_barang;END
//
DELIMITER ;
DROP TRIGGER IF EXISTS `updatestokbeli1`;
DELIMITER //
CREATE TRIGGER `updatestokbeli1` AFTER DELETE ON `pembelian`
 FOR EACH ROW begin update barang set stok=stok-old.jumlah where id_barang=old.id_barang;END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `penjualan`
--

DROP TABLE IF EXISTS `penjualan`;
CREATE TABLE IF NOT EXISTS `penjualan` (
  `id_barang` int(11) NOT NULL,
  `id_kasir` int(11) NOT NULL,
  `total` int(30) NOT NULL,
  `status` char(10) NOT NULL,
  `tanggal` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `penjualan`
--
DROP TRIGGER IF EXISTS `updatestokjual`;
DELIMITER //
CREATE TRIGGER `updatestokjual` AFTER INSERT ON `penjualan`
 FOR EACH ROW begin update barang set stok=stok-new.total where id_barang=NEW.id_barang;END
//
DELIMITER ;
DROP TRIGGER IF EXISTS `updatestokjual1`;
DELIMITER //
CREATE TRIGGER `updatestokjual1` AFTER DELETE ON `penjualan`
 FOR EACH ROW begin update barang set stok=stok+old.total where id_barang=old.id_barang;END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `satuan`
--

DROP TABLE IF EXISTS `satuan`;
CREATE TABLE IF NOT EXISTS `satuan` (
  `id_satuan` int(11) NOT NULL AUTO_INCREMENT,
  `nama_satuan` varchar(50) NOT NULL,
  PRIMARY KEY (`id_satuan`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `satuan`
--

INSERT INTO `satuan` (`id_satuan`, `nama_satuan`) VALUES
(1, 'PCS'),
(2, 'Liter'),
(3, 'Bungkus'),
(4, 'Galon'),
(5, 'Kg'),
(6, 'Kardus');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
CREATE TABLE IF NOT EXISTS `supplier` (
  `id_suplier` int(11) NOT NULL AUTO_INCREMENT,
  `nama_suplier` varchar(30) NOT NULL,
  `alamat_suplier` varchar(100) NOT NULL,
  `contact_person` char(14) NOT NULL,
  PRIMARY KEY (`id_suplier`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id_suplier`, `nama_suplier`, `alamat_suplier`, `contact_person`) VALUES
(1, 'Unilever Tbk.', 'Surabaya', '021474836478'),
(2, 'Wings Food', 'Surabaya', '081977878878'),
(3, 'Bintang Toedjoe', 'Jakarta', '081939487837'),
(4, 'Dua Kelinci', 'Surabaya', '081977878878');

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_beli`
--
DROP VIEW IF EXISTS `view_beli`;
CREATE TABLE IF NOT EXISTS `view_beli` (
`id_kasir` int(11)
,`id_barang` int(11)
,`nama_barang` varchar(50)
,`waktu_beli` datetime
,`harga_beli` int(100)
,`jumlah` int(30)
,`nama_satuan` varchar(50)
,`tanggal` date
);
-- --------------------------------------------------------

--
-- Structure for view `keuntungan`
--
DROP TABLE IF EXISTS `keuntungan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `keuntungan` AS select `penjualan`.`id_barang` AS `id_barang`,`barang`.`nama_barang` AS `nama_barang`,`penjualan`.`tanggal` AS `waktu beli`,`barang`.`harga_beli` AS `harga_beli`,`barang`.`harga_jual` AS `harga_jual`,`penjualan`.`total` AS `total`,`penjualan`.`id_kasir` AS `id_kasir`,`satuan`.`nama_satuan` AS `nama_satuan`,cast(`penjualan`.`tanggal` as date) AS `tanggal` from (`satuan` join (`barang` left join `penjualan` on((`barang`.`id_barang` = `penjualan`.`id_barang`)))) where ((`satuan`.`id_satuan` = `barang`.`satuan`) and (`penjualan`.`status` = 'cetak'));

-- --------------------------------------------------------

--
-- Structure for view `view_beli`
--
DROP TABLE IF EXISTS `view_beli`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_beli` AS select `pembelian`.`id_kasir` AS `id_kasir`,`pembelian`.`id_barang` AS `id_barang`,`barang`.`nama_barang` AS `nama_barang`,`pembelian`.`tgl_pembelian` AS `waktu_beli`,`barang`.`harga_beli` AS `harga_beli`,`pembelian`.`jumlah` AS `jumlah`,`satuan`.`nama_satuan` AS `nama_satuan`,cast(`pembelian`.`tgl_pembelian` as date) AS `tanggal` from (`satuan` join (`barang` left join `pembelian` on((`barang`.`id_barang` = `pembelian`.`id_barang`)))) where ((`satuan`.`id_satuan` = `barang`.`satuan`) and (`pembelian`.`status` = 'cetak'));

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
