import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { StudentDto } from '../model/student-dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class StudentService{

  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient){}

  public getStudentsList(): Observable<StudentDto[]>{
    return this.httpClient.get<StudentDto[]>(this.baseUrl + 'student');
  }
}
