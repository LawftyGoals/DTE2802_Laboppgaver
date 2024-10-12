$(document).ready(function () {
  $("#fetchData").click(function () {
    $.ajax({
      url: "https://localhost:7236/api/Product/1",
      type: "GET",
      dataType: "json",
      success: function (data) {
        $("#dataContainer").text(JSON.stringify(data));
      },
      error: function (xhr, status, error) {
        console.log("Error fetching data", error);
      },
    });
  });
});
