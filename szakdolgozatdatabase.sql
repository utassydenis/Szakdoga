-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Okt 19. 15:08
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szakdolgozatdatabase`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `card_error_logs`
--

CREATE TABLE `card_error_logs` (
  `id` int(11) NOT NULL,
  `card_id` varchar(255) NOT NULL,
  `error_log_time` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `card_user`
--

CREATE TABLE `card_user` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `card_id` varchar(255) NOT NULL,
  `start_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `expired` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `card_user`
--

INSERT INTO `card_user` (`id`, `user_id`, `card_id`, `start_date`, `expired`) VALUES
(1, 123, '36-B8-6F-C6', '2023-10-15 17:48:00', NULL),
(2, 456, 'B6-C3-70-C6', '2023-10-15 18:27:01', '2028-10-27 18:26:28'),
(3, 789, '66-9D-B2-C6', '2023-10-15 18:27:01', '2023-10-02 18:26:29');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `doors`
--

CREATE TABLE `doors` (
  `id` int(11) NOT NULL,
  `door_id` int(11) NOT NULL,
  `door_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `doors`
--

INSERT INTO `doors` (`id`, `door_id`, `door_name`) VALUES
(1, 1, 'test_door_1'),
(2, 2, 'test_door_2'),
(3, 3, 'test_door_3'),
(4, 4, 'test_door_4'),
(5, 5, 'diner_door');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `door_logs`
--

CREATE TABLE `door_logs` (
  `id` int(11) NOT NULL,
  `door_id` int(11) NOT NULL,
  `card_id` varchar(255) NOT NULL,
  `time_entered` timestamp NULL DEFAULT NULL,
  `time_exited` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `door_logs`
--

INSERT INTO `door_logs` (`id`, `door_id`, `card_id`, `time_entered`, `time_exited`) VALUES
(1, 1, '36-B8-6F-C6', '2023-10-19 13:06:55', NULL),
(2, 2, '36-B8-6F-C6', '2023-10-19 13:07:04', NULL),
(3, 1, '36-B8-6F-C6', NULL, '2023-10-19 13:07:12'),
(4, 2, '36-B8-6F-C6', NULL, '2023-10-19 13:07:20');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `door_privilige_requirement`
--

CREATE TABLE `door_privilige_requirement` (
  `id` int(11) NOT NULL,
  `door_id` int(11) DEFAULT NULL,
  `privilige_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `door_privilige_requirement`
--

INSERT INTO `door_privilige_requirement` (`id`, `door_id`, `privilige_level`) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `privilige_levels`
--

CREATE TABLE `privilige_levels` (
  `id` int(11) NOT NULL,
  `privilige_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `privilige_levels`
--

INSERT INTO `privilige_levels` (`id`, `privilige_level`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `user_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `user_id`, `user_name`) VALUES
(1, 123, 'test_user'),
(2, 456, 'test_user_2'),
(3, 789, 'test_user_3');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user_priviliges`
--

CREATE TABLE `user_priviliges` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `privilige_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `user_priviliges`
--

INSERT INTO `user_priviliges` (`id`, `user_id`, `privilige_level`) VALUES
(2, 123, 1),
(3, 123, 2),
(4, 456, 3),
(5, 789, 4),
(6, 123, 5),
(7, 456, 5),
(8, 789, 5);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `card_error_logs`
--
ALTER TABLE `card_error_logs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `card_id` (`card_id`);

--
-- A tábla indexei `card_user`
--
ALTER TABLE `card_user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `card_id` (`card_id`),
  ADD KEY `user_id` (`user_id`);

--
-- A tábla indexei `doors`
--
ALTER TABLE `doors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `door_id` (`door_id`);

--
-- A tábla indexei `door_logs`
--
ALTER TABLE `door_logs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `door_id` (`door_id`),
  ADD KEY `card_id` (`card_id`);

--
-- A tábla indexei `door_privilige_requirement`
--
ALTER TABLE `door_privilige_requirement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `door_id` (`door_id`),
  ADD KEY `privilige_level` (`privilige_level`);

--
-- A tábla indexei `privilige_levels`
--
ALTER TABLE `privilige_levels`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `privilige_level` (`privilige_level`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user_id` (`user_id`);

--
-- A tábla indexei `user_priviliges`
--
ALTER TABLE `user_priviliges`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `privilige_level` (`privilige_level`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `card_error_logs`
--
ALTER TABLE `card_error_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `card_user`
--
ALTER TABLE `card_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `doors`
--
ALTER TABLE `doors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `door_logs`
--
ALTER TABLE `door_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `door_privilige_requirement`
--
ALTER TABLE `door_privilige_requirement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `privilige_levels`
--
ALTER TABLE `privilige_levels`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `user_priviliges`
--
ALTER TABLE `user_priviliges`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `card_error_logs`
--
ALTER TABLE `card_error_logs`
  ADD CONSTRAINT `card_error_logs_ibfk_1` FOREIGN KEY (`card_id`) REFERENCES `card_user` (`card_id`);

--
-- Megkötések a táblához `card_user`
--
ALTER TABLE `card_user`
  ADD CONSTRAINT `card_user_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Megkötések a táblához `door_logs`
--
ALTER TABLE `door_logs`
  ADD CONSTRAINT `door_logs_ibfk_1` FOREIGN KEY (`door_id`) REFERENCES `doors` (`door_id`),
  ADD CONSTRAINT `door_logs_ibfk_2` FOREIGN KEY (`card_id`) REFERENCES `card_user` (`card_id`);

--
-- Megkötések a táblához `door_privilige_requirement`
--
ALTER TABLE `door_privilige_requirement`
  ADD CONSTRAINT `door_privilige_requirement_ibfk_1` FOREIGN KEY (`door_id`) REFERENCES `doors` (`door_id`),
  ADD CONSTRAINT `door_privilige_requirement_ibfk_2` FOREIGN KEY (`privilige_level`) REFERENCES `privilige_levels` (`privilige_level`);

--
-- Megkötések a táblához `user_priviliges`
--
ALTER TABLE `user_priviliges`
  ADD CONSTRAINT `user_priviliges_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  ADD CONSTRAINT `user_priviliges_ibfk_2` FOREIGN KEY (`privilige_level`) REFERENCES `privilige_levels` (`privilige_level`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
