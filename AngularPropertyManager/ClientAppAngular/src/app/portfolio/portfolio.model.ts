import { IUser } from "../../api-authorization/authorize.service";
import { Property } from "../property/property.model";

export class Portfolio {
  public Name: string;
  public Owner: IUser;
  public Properties: Array<Property>;
}
