import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { StudentDto } from '../model/student-dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class StudentService{

  baseUrlStudent = environment.apiUrl + 'student/';

  constructor(private httpClient: HttpClient){}

  public getStudentsList(): Observable<StudentDto[]>{
    return this.httpClient.get<StudentDto[]>(this.baseUrlStudent);
  }

  public addStudent(request: StudentDto): Observable<StudentDto>{
    return this.httpClient.post<StudentDto>(this.baseUrlStudent + 'Add', request);
  }

  public updateStudent(studentUid: string, request: StudentDto): Observable<StudentDto>{
    return this.httpClient.put<StudentDto>(this.baseUrlStudent + studentUid, request);
  }

  public deleteStudent(studentUid: string): Observable<StudentDto>{
    return this.httpClient.delete<StudentDto>(this.baseUrlStudent + studentUid);
  }
}