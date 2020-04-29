export class Tenant {
  public Id: string;
  public CreatedDateTime: Date;
  public FirstName: string;
  public LastName: string;
  public JobTitle: string;
  public PhoneNumber: string;
  public Nationality: string;
  public TenancyStartDate: Date;
  public Notes: Array<Note>;
}

export class Note {
  public Id: string;
  public CreatedDateTime: Date;
  public Description: string;
}
