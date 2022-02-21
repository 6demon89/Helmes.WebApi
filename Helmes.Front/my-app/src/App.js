import React ,{useState,useEffect } from "react";
import useGetSectors from "./hooks/GetSectorsHook";

const App = () => {
  const Sectors = useGetSectors();
  const [userName,setUserName] = useState('');
  const [termAgreement,setTermAgreement] = useState(false);
  const [involvedSectors,setInvolvedSectors] = useState([]);
  const [userID,setUserID] = useState({ID : '00000000-0000-0000-0000-000000000000'});
  const [state,setState]  = useState();

  const handleNameChange = event => { setUserName(event.target.value)};
  const handleTermsChange = event => { setTermAgreement(event.target.checked)};
  const handleUserSectorsChange = e => {
    var options = e.target.options;
            var value = [];
            for (var i = 0, l = options.length; i < l; i++) {
              if (options[i].selected) {
                value.push(options[i].value);
              }
            }
    setInvolvedSectors({value: value});
  };

  const handleSubmit = event => {
    event.preventDefault();
    const sector = [];
    involvedSectors.value.forEach(ping);
    function ping(e)
    {
      sector.push({sectorID:e})
    }
    var Data = JSON.stringify({
              name:userName,
              AgreedToTerms: termAgreement,
              Sectors:sector
          });
    var t = sessionStorage.getItem("userID");
          if(userID.ID !== '00000000-0000-0000-0000-000000000000'){
              const requestOptions = {
                  method: 'PUT',
                  headers: { 'Content-Type': 'application/json' },
                  body: JSON.stringify({
                        name:userName,
                        AgreedToTerms: termAgreement,
                        Sectors:sector
                    })
                };
              const response = fetch(
                  "http://localhost:5136/user/"+userID.ID, requestOptions)
                    .then(async response => 
                      { 
                        const isJson = response.headers.get('content-type')?.includes('application/json');
                        const data = isJson && await response.json();
            
                        if (!response.ok) {
                            const error = (data && data.message) || response.status;
                            return Promise.reject(error);
                        }
                      })
                      .catch(error => {
                        setState({ errorMessage: error });
                        console.error('There was an error!', error);
                    });
                  }
          else{
              const requestOptions = {
                  method: 'POST',
                  headers: { 'Content-Type': 'application/json' },
                  body: JSON.stringify(
                    {
                        name:userName,
                        AgreedToTerms: termAgreement,
                        Sectors:sector
                    }
                    )
              };
              const response = fetch(
                "http://localhost:5136/user", requestOptions)
                  .then(async response => 
                    { 
                      const isJson = response.headers.get('content-type')?.includes('application/json');
                      const data = isJson && await response.json();
          
                      if (!response.ok) {
                          const error = (data && data.message) || response.status;
                          return Promise.reject(error);
                      }
                      setState({ ID : data.id });
                      setUserID({ID : data.id});
                      sessionStorage.setItem("userID", userID.ID);
                    })
                    .catch(error => {
                      setState({ errorMessage: error });
                      console.error('There was an error!', error);
                  });
                }
          return {state};
  };


  return (
    <div className="container">
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label className="form-label">
            Please enter your name and pick the Sectors you are currently involved in.
          </label>
        </div>
        <div className="mb-3">
            <label for="validationDefault01" className="form-label">Name:</label>
            <input required placeholder="Name" type="text" className="form-control" onChange={handleNameChange} value={userName}/>
        </div>
        <div className="mb-3">
          <label className="form-label">Sectors:</label>
          <select required className="form-select" multiple size="5"  onChange={handleUserSectorsChange}>
              {Sectors.map((sector)=> <option value={sector.sectorID} key={sector.sectorID}>
                {sector.name}
              </option>)}
            </select>
        </div>
          <div className="mb-3">
          <div class="form-check">
                <input class="form-check-input" type="checkbox" onChange={handleTermsChange}  value="" id="invalidCheck" required/>
                <label class="form-check-label" for="invalidCheck">
                  Agree to terms
                </label>
                <div class="invalid-feedback">
                  You must agree before submitting.
                </div>
           </div>
          </div>
          <input type="submit" className="btn btn-primary" value="Save Changes"/>
      </form>
    </div>

  );
}

export default App;
