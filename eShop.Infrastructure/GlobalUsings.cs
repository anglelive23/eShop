﻿global using eShop.Application.Contracts;
global using eShop.Application.Models.Authentication;
global using eShop.Domain.Entities;
global using eShop.Infrastructure.Data;
global using eShop.Infrastructure.Services;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using eShop.Domain.Common;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using eShop.Application.Exceptions;
global using Microsoft.Data.SqlClient;
global using System.Linq.Expressions;
global using eShop.Infrastructure.Repositories;