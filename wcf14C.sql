-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Sze 30. 11:09
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `wcfesti2a`
--
CREATE DATABASE IF NOT EXISTS `wcfesti2a` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `wcfesti2a`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `Id` int(11) NOT NULL,
  `LoginNev` varchar(16) NOT NULL,
  `HASH` varchar(64) NOT NULL,
  `SALT` varchar(64) NOT NULL,
  `Nev` varchar(64) NOT NULL,
  `Jog` int(11) NOT NULL,
  `Aktiv` tinyint(1) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ProfilKep` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`Id`, `LoginNev`, `HASH`, `SALT`, `Nev`, `Jog`, `Aktiv`, `Email`, `ProfilKep`) VALUES
(2, 'Teszt1', '123456', '1324546543', 'Elso Teszt Felhasznalo', 1, 0, 'teszt1@teszt.hu', 'Teszt1.jpg'),
(4, 'pimpike', 'djhfldsfhldskjf', 'fkdshflasdkkj', 'Bojtos Pimpike', 1, 1, 'pimpike@pimpserver.hu', 'pimpike.jpg'),
(10, 'Teszt4Login', 'skjadla', 'dhsajhlsakj', 'Teszt Négy', 1, 1, 'teszt4a@teszt.hu', 'teszt4.jpg'),
(12, 'Admin', 'ldkjflkdsjflskaj', 'skjsahalskj', 'Teszt Admin', 1, 1, 'admin8@teszt.hu', 'admin.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jogosultsagok`
--

CREATE TABLE `jogosultsagok` (
  `Id` int(11) NOT NULL,
  `Szint` int(1) NOT NULL,
  `Nev` varchar(32) NOT NULL,
  `Leiras` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `jogosultsagok`
--

INSERT INTO `jogosultsagok` (`Id`, `Szint`, `Nev`, `Leiras`) VALUES
(1, 9, 'Admin', 'Adminisztrátori szint'),
(4, 3, 'Iroda', 'Irodai dolgozók hozzáférési szintje');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `LoginNev` (`LoginNev`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `Jog` (`Jog`);

--
-- A tábla indexei `jogosultsagok`
--
ALTER TABLE `jogosultsagok`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Szint` (`Szint`),
  ADD UNIQUE KEY `Nev` (`Nev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT a táblához `jogosultsagok`
--
ALTER TABLE `jogosultsagok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD CONSTRAINT `felhasznalok_ibfk_1` FOREIGN KEY (`Jog`) REFERENCES `jogosultsagok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
