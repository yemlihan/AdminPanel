-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 07 Eyl 2020, 11:57:46
-- Sunucu sürümü: 5.7.31
-- PHP Sürümü: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `site2020`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `anasayfa`
--

DROP TABLE IF EXISTS `anasayfa`;
CREATE TABLE IF NOT EXISTS `anasayfa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `baslik` char(100) NOT NULL,
  `ustbaslik` char(100) NOT NULL,
  `icerik` tinytext NOT NULL,
  `foto` char(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `anasayfa`
--

INSERT INTO `anasayfa` (`id`, `baslik`, `ustbaslik`, `icerik`, `foto`) VALUES
(1, 'Anasayfamiz', 'Anasayfa', 'Every cup of our quality artisan coffee starts with locally sourced, hand picked ingredients. Once you try it, our coffee will be a blissful addition to your everyday morning routine - we guarantee it!', 'intro.jpg');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hakkimizda`
--

DROP TABLE IF EXISTS `hakkimizda`;
CREATE TABLE IF NOT EXISTS `hakkimizda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `foto` char(50) NOT NULL,
  `baslik` char(250) NOT NULL,
  `ustbaslik` char(250) NOT NULL,
  `icerik` mediumtext NOT NULL,
  `aktif` tinyint(1) DEFAULT NULL,
  `sira` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Tablo döküm verisi `hakkimizda`
--

INSERT INTO `hakkimizda` (`id`, `foto`, `baslik`, `ustbaslik`, `icerik`, `aktif`, `sira`) VALUES
(1, 'about.jpg', 'Satsat Hakkinda Hersey!', 'SatSat Nedir?', 'E-Ticaret sitesi.Every cup of our quality artisan coffee starts with locally sourced, hand picked ingredients. Once you try it, our coffee will be a blissful addition to your everyday morning routine - we guarantee it.', NULL, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `iletisim`
--

DROP TABLE IF EXISTS `iletisim`;
CREATE TABLE IF NOT EXISTS `iletisim` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ad` char(50) NOT NULL,
  `mail` char(150) NOT NULL,
  `konu` char(50) NOT NULL,
  `mesaj` char(250) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `iletisim`
--

INSERT INTO `iletisim` (`id`, `ad`, `mail`, `konu`, `mesaj`) VALUES
(1, '', 'deneme@gmail.com', 'Deneme', 'dene');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

DROP TABLE IF EXISTS `kullanicilar`;
CREATE TABLE IF NOT EXISTS `kullanicilar` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kad` char(50) CHARACTER SET latin1 NOT NULL,
  `sifre` char(50) CHARACTER SET latin1 NOT NULL,
  `role` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`id`, `kad`, `sifre`, `role`) VALUES
(1, 'admin', '81dc9bdb52d04dc20036dbd8313ed055', NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

DROP TABLE IF EXISTS `urunler`;
CREATE TABLE IF NOT EXISTS `urunler` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `foto` char(50) NOT NULL,
  `baslik` char(250) NOT NULL,
  `ustbaslik` char(250) NOT NULL,
  `icerik` mediumtext NOT NULL,
  `aktif` tinyint(1) DEFAULT NULL,
  `sira` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`id`, `foto`, `baslik`, `ustbaslik`, `icerik`, `aktif`, `sira`) VALUES
(1, 'products-01.jpg', 'COFFEES & TEAS', 'Blended to Perfection', '<p class=\"mb-0\">We take pride in our work, and it shows. Every time you order a beverage from us, we guarantee that it will be an experience worth having. Whether it\'s our world famous Venezuelan Cappuccino, a refreshing iced herbal tea, or something as simple as a cup of speciality sourced black coffee, you will be coming back for more.</p>', 1, 100),
(2, 'products-02.jpg', 'BAKERY & KİTCHEN', 'DELİCİOUS TREATS, GOOD EATS', '<p class=\"mb-0\">Our seasonal menu features delicious snacks, baked goods, and even full meals perfect for breakfast or lunchtime. We source our ingredients from local, oragnic farms whenever possible, alongside premium vendors for specialty goods.</p>', 1, 150),
(3, 'products-03.jpg', 'BULK SPECİALİTY BLENDS', 'FROM AROUND THE WORLD', '<p class=\"mb-0\">Travelling the world for the very best quality coffee is something take pride in. When you visit us, you\'ll always find new blends from around the world, mainly from regions in Central and South America. We sell our blends in smaller to large bulk quantities. Please visit us in person for more details.</p>', 1, 200);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
