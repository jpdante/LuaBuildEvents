local Environment = require("lua.sys.environment")
local Process = require("lua.sys.process")
local ProcessStartInfo = require("lua.sys.processstartinfo")

-- 30 Seconds Timeout
process_timeout = 30000

-- Extremely important to avoid a build loop that can crash the system.
if Environment.get_environment_variable("skip_luabuildevents") == "true" then
   print("[LBE] Skipping compilation via system variable.")
   exit(0)
end

function build_program(project_directory, deployment_type, system_os, extra_arguments)
    print("[LBE] Loading build...\n")
    psi = ProcessStartInfo.create()
	psi.file_name = "dotnet"
	psi.arguments = "publish -r " .. system_os .. " -c " .. deployment_type .. " --self-contained true " .. extra_arguments
	psi.working_directory = project_directory
	psi.use_shell_execute = false
	psi.redirect_standard_output = true
	psi.redirect_standard_error = true
	psi.create_no_window = true
	psi.set_environment_variable("skip_luabuildevents", "true")
    process = Process.create(psi)
	print("[LBE] Starting build...\n")
	process.start()
	output_reader = process.standard_output
	error_reader = process.standard_error
	while output_reader.is_end_of_stream == false do
	    print("[LBE-ProcessOutput] " .. output_reader.read_line() .. "\n")
	end
	while error_reader.is_end_of_stream == false do
	    print("[LBE-ProcessError] " .. error_reader.read_line() .. "\n")
	end
	print("[LBE] Waiting for build to complete...\n")
	process.wait_for_exit(process_timeout)
	print("[LBE] Build complete!\n")
	return process.exit_code
end

code = build_program(args[2], args[3], "win10-x64", "/p:PublishSingleFile=true")
if code != 0 then
    exit(code)
end

code = build_program(args[2], args[3], "linux-x64", "")
if code != 0 then
    exit(code)
end