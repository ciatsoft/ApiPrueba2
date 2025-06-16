var seconds = 0;

function GetMVC(url, callBackResult) {
    
    $.ajax({
        url: url,
        cache: false,
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;",
        success: function (r) {
            callBackResult(r);
        },
        error: function (e) {
            callBackResult(e);
        }
    });
}

function GetParamMVC(url, parameters, callBackResult) {
    
    $.ajax({
        url: url,
        cache: false,
        type: 'GET',
        dataType: 'json',
        data: parameters,
        success: function (r) {
            callBackResult(r);
        },
        error: function (e) {
            callBackResult(e);
        }
    });
}

function PostMVC(url, parameters, callBackResult) {
    
    $.ajax({
        url: url,
        cache: false,
        type: 'POST',
        dataType: 'json',
        data: parameters,
        success: function (r) {
            callBackResult(r);
        },
        error: function (e) {
            callBackResult(e);
        }
    });
}

function PostFileMVC(url, parameters, callBackResult) {
    

    var formData = new FormData();
    $.each(parameters, function (i, v) {
        formData.append(v.Name, v.Value);
    });

    $.ajax({
        type: 'POST',
        url: url,
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (r) {
            callBackResult(r);
        },
        error: function (e) {
            callBackResult(e);
        }
    });
}

function formatDate(date) {

    if (date !== null) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [day, month, year].join('-');
    }
    else {
        return null;
    }
}

function formatDateTime(dd) {
    if (date !== null) {
        var d = new Date(dd);
        var month = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

        var date = d.getDate() + " " + month[d.getMonth()] + ", " + d.getUTCFullYear();
        var time = d.toLocaleTimeString().toLowerCase();

        return date + " at " + time;
    }
    else {
        return null;
    }
}

function formatMoney(data) {
    return ('$' + parseFloat(data, 10).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,")).toString();
}

function formatEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function MapingPropertiesDataTable(nameTable, array) {
    const table = $('#' + nameTable).DataTable(); 
    table.clear();                                
    table.rows.add(array);                       
    table.draw();                               
}


