﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace employee.Emps;


public class EmpAppService :
     CrudAppService<
        Emp, //The Book entity
        EmpDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmpDto>, //Used to create/update a book
    IEmpAppService //implement the IBookAppService
{
    public EmpAppService(IRepository<Emp, Guid> repository)
       : base(repository)
    {

    }
}
