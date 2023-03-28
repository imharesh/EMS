$(function () {
    var l = abp.localization.getResource('employee');
    var createModal = new abp.ModalManager(abp.appPath + 'Emps/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Emps/EditModal');

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
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('employee.Emps.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('employee.Emps.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'EmpDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                            employee.emps.emp
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
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
    var createModal = new abp.ModalManager(abp.appPath + 'Emps/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmpButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
