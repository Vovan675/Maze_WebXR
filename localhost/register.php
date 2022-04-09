<?php

$name = $_POST["name"];
$time = $_POST["time"];

$conn = new mysqli("localhost", "mysql", "", "game");

if ($conn->connect_error)
{
    die("Failed with error: " . $conn->connect_error);
}

$sql = "SELECT name FROM players where name = '" . $name . "'";
$res = $conn->query($sql);

if ($res->num_rows > 0)
{
    echo "Name already taken";
}
else
{
    $sql = "INSERT INTO players (name, time) VALUES ('" . $name . "', " . $time . ")";
    if ($conn->query($sql) === TRUE)
    {
        echo "Successful registration";
    }
    else
    {
        echo $conn->error;
    }
}

$conn->close();
?>