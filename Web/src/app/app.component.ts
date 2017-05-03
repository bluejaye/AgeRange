import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

//base URL for API endpoint (migght need to change if API port number changed)
const baseUrl = 'http://localhost:56418/';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Age Ranger Project';
  isLoading: boolean = true;;
  searchString: string = "";
  personList: any[];
  ageGroupList: Observable<any[]>;
  createModel: CreatePersonModel;
  editModel: EditPersonModel;
  showCreate: boolean;

  constructor(private http: Http) {
  }

  ngOnInit() {
    this.createModel = new CreatePersonModel();
    this.editModel = new EditPersonModel();
    this.getList();
    this.isLoading = false;
  }

  getList(): any {
    let url = baseUrl + 'Person/List';
    this.http.get(url)
      .map(res => res.text() ? res.json() : {})
      .subscribe(response => {
        this.personList = response;
      });
  }
  autoSearch($event: any): any {
    if ($event.key === "Enter") {
      return this.searchList();
    }
  }
  
  searchList(): any {
    if (this.searchString) {
      let url = baseUrl + 'Person/List';
      let payload = {
        Name: this.searchString
      }

      this.http.post(url, payload)
        .map(res => res.text() ? res.json() : {})
        .subscribe(respose => {
          this.personList = respose;
        });
    } else {
      this.getList()
    }
  }

  create(form: any): void {
    if (this.createModel.Age <= 0) {
      alert("Age cannot be under 0");
      return;
    }

    if (!this.createModel.FirstName) {
      alert("Please provide a first name");
      return;
    }

    if (!this.createModel.FirstName) {
      alert("Please provide a last name");
      return;
    }

    let url = baseUrl + 'Person/Create';
    let payload = {
      FirstName: this.createModel.FirstName,
      LastName: this.createModel.LastName,
      Age: this.createModel.Age
    }
    this.http.post(url, payload)
      .map(res => res.text() ? res.json() : {})
      .subscribe(response => {
        this.searchList();
        form.reset();
        this.showCreate = false;
      },
      err => alert(err));
  }

  edit(person: EditPersonModel): void {
    if (this.editModel.age <= 0) {
      alert("Age cannot be under 0");
      return;
    }

    if (!this.editModel.firstName) {
      alert("Please provide a first name");
      return;
    }

    if (!this.editModel.firstName) {
      alert("Please provide a last name");
      return;
    }

    let url = baseUrl + 'Person/Edit';
    let payload = {
      Id: this.editModel.id,
      FirstName: this.editModel.firstName,
      LastName: this.editModel.lastName,
      Age: this.editModel.age
    }
    this.http.post(url, payload)
      .map(res => res.text() ? res.json() : {})
      .subscribe(response => {
        this.searchList();
        person.Display = false;
      },
      err => alert(err));
  }

  displayEdit(person: EditPersonModel): void {
    //close all edit form
    this.personList.forEach(p => {
      p.Display = false;
    });
    this.showCreate = false;
    //clone object rather than reference
    this.editModel = JSON.parse(JSON.stringify(person));
    person.Display = true;
  }
}


export class CreatePersonModel {
  FirstName: string;
  LastName: string;
  Age: number;
}

export class EditPersonModel {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
  Display: boolean;
}