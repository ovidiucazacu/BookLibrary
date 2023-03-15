import { Component, OnInit } from '@angular/core';
import { StudentDto } from '../model/student-dto';
import { StudentService } from '../services/student.service';
import { Constants } from '../shared/constants';
import * as $ from "jquery";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {

  public students: StudentDto[] = [];
  public dateFormat: any = Constants.DATE_FORMAT;

  constructor(private studentService:StudentService, private toastrService: ToastrService) { 
    this.handleRowInserting = this.handleRowInserting.bind(this);
    this.handleRowUpdating = this.handleRowUpdating.bind(this);
    this.handleRowRemoving = this.handleRowRemoving.bind(this);
  }

  ngOnInit() {
    this.loadStudents();
  }

  public loadStudents(){
    this.studentService.getStudentsList().subscribe(response => {
      this.students = response;
    })
  }

  public handleRowInserting(event: any){
    let def = $.Deferred();

    const request = this.getEditStudentRequest(event.data);

    this.studentService.addStudent(request)
      .subscribe(result =>{
        if(result){
          def.resolve(false);
          this.toastrService.success("Student added successfuly!", "Add new student");
          this.loadStudents();
        }else{
          def.resolve(true);
        }
      }, errors => {
        def.resolve(true);
      });
    event.cancel = def;
  }

  public handleRowUpdating(event: any){
    let def = $.Deferred();

    const request = this.getEditStudentRequest(event.oldData);
    Object.assign(request, event.newData);

    this.studentService.updateStudent(event.key, request)
      .subscribe(result => {
        if(result){
          def.resolve(false);
          this.toastrService.success("Student updated successfuly!", "Update student");
          this.loadStudents();
        }else{
          def.resolve(true);
        }
      }, errors => {
        def.resolve(true);
      });
      event.cancel = def;
  }

  public handleRowRemoving(event: any){
    let studentToRemove = event.data as StudentDto;
    let def = $.Deferred();

    this.studentService.deleteStudent(studentToRemove.uid)
      .subscribe(result => {
        if(result){
          def.resolve(false);
          this.toastrService.success("Student removed successfuly!", "Remove student");
          this.loadStudents();
        }else{
          def.resolve(true);
        }
      }, errors => {
        def.resolve(true);
      });
      event.cancel = def;
  }

  private getEditStudentRequest(student: StudentDto){
    let request = new StudentDto();

    request.code = student.code;
    request.firstName = student.firstName;
    request.lastName = student.lastName;
    request.classmate = student.classmate;
    request.gender = student.gender;
    request.dateOfBirth = student.dateOfBirth;
    request.contact = student.contact;

    return request;
  }
}