﻿namespace Domain;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    
    public List<Post> Posts { get; set; }
    
}