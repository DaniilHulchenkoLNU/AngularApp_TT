import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/User/User';



@Injectable(/*{providedIn: 'root'}*/)
export class UserService {

  private userSubject = new BehaviorSubject<User | null>(null);
  public User$ = this.userSubject.asObservable();
  


  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    
  }

  getuser(): Observable<User> {
    return this.http.get<User>(`/Auth/GetUser`);
  }}



