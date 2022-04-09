<?php
$conn = new mysqli("localhost", "mysql", "", "game");

if ($conn->connect_error)
{
    die("Failed with error: " . $conn->connect_error);
}
?>