$(function () {
    var l = abp.localization.getResource('employee');

    var dataTable = $('#EmpsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employee.emps.emp.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:Department.' + data);
                    }
                },

                {
                    title: l('Age'),
                    data: "age"
                },
                {
                    title: l('Salary'),
                    data: "salary"
                },
               
            ]
        })
    );
});
