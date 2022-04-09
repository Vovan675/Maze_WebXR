<?php

$name = $_POST["name"];

$conn = new mysqli("localhost", "mysql", "", "game");

if ($conn->connect_error)
{
    die("Failed with error: " . $conn->connect_error);
}

$sql = "SELECT * FROM players where name != '" . $name . "'";
$res = $conn->query($sql);

if ($res->num_rows > 0)
{
    $arr = array();
    while ($row = $res->fetch_assoc())
    {
        printf("Name: %s<br>", $row["name"]);
        $arr[] = $row;
    }
    echo json_encode($arr);
}

$conn->close();
?>