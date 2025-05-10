﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enum;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Presistance.Data.Configurations.Employees
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");

            // استخدم ValueGeneratedOnAdd مع التعبير المناسب لـ GETUTCDATE()
            builder.Property(D => D.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd(); // قم بتحديد أنه يتم توليد القيمة عند إضافة السجل

            #region Enum
            builder.Property(E => E.Gender)
                .HasConversion(
                    gender => gender.ToString(),
                    gender => (Gender)Enum.Parse(typeof(Gender), gender));

            builder.Property(E => E.EmployeeType)
                .HasConversion(
                    type => type.ToString(),
                    type => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));
            #endregion
        }
    }
}
