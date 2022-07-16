import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdaterequestComponent } from './updaterequest.component';

describe('UpdaterequestComponent', () => {
  let component: UpdaterequestComponent;
  let fixture: ComponentFixture<UpdaterequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdaterequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdaterequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
