import { Component, OnInit } from '@angular/core';
import { StudentDto } from '../model/student-dto';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {

  public students: StudentDto[] = [];

  constructor(private studentService:StudentService) { }

  ngOnInit() {
    this.studentService.getStudentsList().subscribe(response => {
        this.students = response;
    })
  }

  public loadStudents(){
    this.studentService.getStudentsList().subscribe(response => {
      this.students = response;
      console.log(this.students);
    })
  }
}
