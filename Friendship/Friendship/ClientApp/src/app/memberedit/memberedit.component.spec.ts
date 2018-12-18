import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MembereditComponent } from './memberedit.component';

describe('MembereditComponent', () => {
  let component: MembereditComponent;
  let fixture: ComponentFixture<MembereditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MembereditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MembereditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
